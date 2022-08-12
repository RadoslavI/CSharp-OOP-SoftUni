using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public double BaseArmor { get; private set; }
        public double BaseHealth { get; private set; }
        public double AbilityPoints { get; set; }
        public IBag Bag { get; private set; }

        public double Armor
        {
            get { return armor; }

            private set 
            { 
                armor = value; 
                if (armor < 0)
                {
                    armor = 0;
                }
            }
        }

        public double Health
        {
            get 
            {  
                return health; 
            }

            set 
            { 
                health = value; 

                if (health < 0)
                {
                    health = 0;
                    this.IsAlive = false;
                }
                else if (health > BaseHealth)
                {
                    health = BaseHealth;
                }

            }
        }

        public string Name
        {
            get 
            { 
                return name; 
            }

            private set 
            { 
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }


        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                return;
            }

            hitPoints -= this.Armor;
            if (hitPoints > 0)
            {
                this.Armor = 0;
                this.Health -= hitPoints;
                this.IsAlive = this.Health > 0;
            }
            
            //double leftPoints = hitPoints - this.Armor > 0
            //    ? hitPoints - this.Armor
            //    : 0;

            //this.Armor -= hitPoints;
            //this.Health -= leftPoints;
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            item.AffectCharacter(this);
        }
		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
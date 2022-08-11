using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            Power = 100;
        }

        public override int Power { get => base.Power; set => base.Power = 100; }

        public override string CastAbility()
        {
            return $"Warrior - {Name} hit for {Power} damage";
        }
    }
}

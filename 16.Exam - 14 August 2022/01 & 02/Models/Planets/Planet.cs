using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        
        private string name;
        private double budget;
        private double militaryPower;
        private readonly List<IMilitaryUnit> units;
        private readonly List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;    
            units = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get => (units.Sum(x => x.EnduranceLevel) +
                    weapons.Sum(x => x.DestructionLevel));

            private set
            {
                var result = checkWeapons(value);

                militaryPower = Math.Round(result, 3);
            }
        }

        private double checkWeapons(double total)
        {
            if (this.units.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
            {
                total += (total * 0.3);
            }
            if (this.weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
            {
                total += total * 0.45;
            }

            return total;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => units;

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");

            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {((Army.Count > 0) ? $"{string.Join(", ", Army.Select(x => x.GetType().Name))}" : "No units")}");

            sb.AppendLine($"--Combat equipment: {((Weapons.Count > 0) ? $"{string.Join(", ", Weapons.Select(x => x.GetType().Name))}" : "No weapons")}");
            sb.AppendLine($"--Military Power: {checkWeapons(MilitaryPower)}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget - amount < 0)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            Budget -= amount;    
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}

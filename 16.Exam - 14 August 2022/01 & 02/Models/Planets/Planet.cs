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
        private readonly UnitRepository units;
        private readonly WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;    
            units = new UnitRepository();
            weapons = new WeaponRepository();
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

        public double MilitaryPower => GetMilitaryPower();

        private double GetMilitaryPower()
        {
            double total = this.Weapons.Sum(w => w.DestructionLevel) + this.Army.Sum(u => u.EnduranceLevel);

            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                total *= 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                total *= 1.45;
            }

            return Math.Round(total, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons
            => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            string forcesAsString = Army.Any() ? string.Join(", ", Army.Select(u => u.GetType().Name)) : "No units";
            string weaponsAsString =
                Weapons.Any() ? string.Join(", ", Weapons.Select(w => w.GetType().Name)) : "No weapons";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine($"--Forces: {forcesAsString}")
                .AppendLine($"--Combat equipment: {weaponsAsString}")
                .AppendLine($"--Military Power: {MilitaryPower}");

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

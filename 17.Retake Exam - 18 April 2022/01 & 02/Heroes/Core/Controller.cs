using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(h => h.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (!weapons.Models.Any(w => w.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            IHero currHero = heroes.Models.FirstOrDefault(h => h.Name == heroName);
            IWeapon currWeapon = weapons.Models.FirstOrDefault(w => w.Name == weaponName);

            if (currHero.Weapon != null)
            {
                return $"Hero {heroName} is well-armed.";
            }

            currHero.AddWeapon(currWeapon);
            weapons.Remove(currWeapon);
            return $"Hero {heroName} can participate in battle using a {currWeapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero { name } already exists.");
            }

            IHero hero = null;

            switch (type)
            {
                case nameof(Barbarian):
                    hero = new Barbarian(name, health, armour);
                    break;
                case nameof(Knight):
                    hero = new Knight(name, health, armour);
                    break;
                default:
                    throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(hero);
            if (type == "Barbarian")
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                return $"Successfully added Sir {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException(
                    $"The weapon { name } already exists.");
            }

            IWeapon weapon = null;

            switch (type)
            {
                case nameof(Claymore):
                    weapon = new Claymore(name, durability);
                    break;
                case nameof(Mace):
                    weapon = new Mace(name, durability);
                    break;
                default:
                    throw new InvalidOperationException("Invalid weapon type.");
            }

            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            var sortedHeroes = heroes.Models
                                    .OrderBy(h => h.GetType().Name)
                                    .ThenByDescending(h => h.Health)
                                    .ThenBy(h => h.Name);

            foreach (var hero in sortedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: { hero.Health }");
                sb.AppendLine($"--Armour: { hero.Armour }");
                sb.AppendLine($"--Weapon: {(hero.Weapon != null ? $"{hero.Weapon.Name}" : "Unarmed")}");
                //sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();
            var players = heroes.Models.Where(h => h.Weapon != null && h.IsAlive).ToList();

            return map.Fight(players);
        }
    }
}

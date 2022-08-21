using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var currPlanet = planets.FindByName(planetName);

            if (currPlanet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (currPlanet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            IMilitaryUnit unit = null;

            switch (unitTypeName)
            {
                case nameof(StormTroopers):
                    unit = new StormTroopers();
                    break;
                case nameof(SpaceForces):
                    unit = new SpaceForces();
                    break;
                case nameof(AnonymousImpactUnit):
                    unit = new AnonymousImpactUnit();
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            currPlanet.Spend(unit.Cost);
            currPlanet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var currPlanet = planets.FindByName(planetName);

            if (currPlanet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (currPlanet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            IWeapon weapon = null;

            switch (weaponTypeName)
            {
                case nameof(BioChemicalWeapon):
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case nameof(NuclearWeapon):
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case nameof(SpaceMissiles):
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            currPlanet.Spend(weapon.Price);
            currPlanet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }

            planets.AddItem(new Planet(name, budget));
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            var ordered = planets.Models
                .OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name);

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in ordered)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        //public string SpaceCombat(string planetOne, string planetTwo)
        //{
        //    var firstPlanet = planets.FindByName(planetOne);
        //    var secondPlanet = planets.FindByName(planetTwo);
        //    bool firstPNW = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
        //    bool secondPNW = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
        //    Planet winner = null;
        //    Planet loser = null;

        //    if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
        //    {
        //        if ((firstPNW == true && secondPNW == true) ||
        //            (firstPNW == false && secondPNW == false))
        //        {
        //            firstPlanet.Spend(firstPlanet.Budget / 2);
        //            secondPlanet.Spend(secondPlanet.Budget / 2);

        //            return $"The only winners from the war are the ones who supply the bullets and the bandages!";
        //        }
        //        else if (firstPNW == true && secondPNW == false)
        //        {
        //            winner = (Planet)firstPlanet;
        //            loser = (Planet)secondPlanet;
        //        }
        //        else
        //        {
        //            loser = (Planet)firstPlanet;
        //            winner = (Planet)secondPlanet;
        //        }
        //    }
        //    else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
        //    {
        //        winner = (Planet)firstPlanet;
        //        loser = (Planet)secondPlanet;
        //    }
        //    else
        //    {
        //        loser = (Planet)firstPlanet;
        //        winner = (Planet)secondPlanet;
        //    }

        //    winner.Spend(winner.Budget / 2);
        //    winner.Profit(loser.Budget / 2);
        //    winner.Profit(loser.Army.Sum(x => x.Cost) + loser.Weapons.Sum(x => x.Price));
        //    string loserName = loser.Name;
        //    planets.RemoveItem(loser.Name);

        //    return $"{winner.Name} destructed {loserName}!";
        //}

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var attacker = planets.FindByName(planetOne);
            var defender = planets.FindByName(planetTwo);

            bool attackerIsNuclear = attacker.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = defender.Weapons.Any(w => w is NuclearWeapon);
            IPlanet winner = null;
            IPlanet looser = null;
            if (attacker.MilitaryPower > defender.MilitaryPower)
            {
                winner = attacker;
                looser = defender;
            }
            else if (defender.MilitaryPower > attacker.MilitaryPower)
            {
                winner = defender;
                looser = attacker;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = attacker;
                    looser = defender;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = defender;
                    looser = attacker;
                }
                else
                {
                    attacker.Spend(attacker.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planets.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            var currPlanet = planets.FindByName(planetName);

            if (currPlanet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!currPlanet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            currPlanet.Spend(1.25);
            currPlanet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}

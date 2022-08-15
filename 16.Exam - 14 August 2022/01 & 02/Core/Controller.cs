using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
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

            if (unitTypeName != "AnonymousImpactUnit" 
                && unitTypeName != "MilitaryUnit"
                && unitTypeName != "StormTroopers"
                && unitTypeName != "SpaceForces")
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            Type type = Type.GetType($"PlanetWars.Models.MilitaryUnits.{unitTypeName}");
            IMilitaryUnit instance = Activator.CreateInstance(type) as IMilitaryUnit;

            if (currPlanet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            currPlanet.Spend(instance.Cost);
            currPlanet.AddUnit(instance);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var currPlanet = planets.FindByName(planetName);

            if (currPlanet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (weaponTypeName != "BioChemicalWeapon"
                && weaponTypeName != "NuclearWeapon"
                && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            Weapon weapon = new NuclearWeapon(destructionLevel);

            Type type = Type.GetType($"PlanetWars.Models.Weapons.{weaponTypeName}");
            IWeapon instance = Activator.CreateInstance(type, new object[] { destructionLevel }) as IWeapon;

            if (currPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            currPlanet.Spend(instance.Price);
            currPlanet.AddWeapon(instance);

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
            planets.Models
                .OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name);

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);
            bool firstPNW = firstPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            bool secondPNW = secondPlanet.Weapons.Any(x => x.GetType().Name == "NuclearWeapon");
            Planet winner = null;
            Planet loser = null;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if ((firstPNW == true && secondPNW == true) ||
                    (firstPNW == false && secondPNW == false))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return $"The only winners from the war are the ones who supply the bullets and the bandages!";
                }
                else if (firstPNW == true && secondPNW == false)
                {
                    winner = (Planet)firstPlanet;
                    loser = (Planet)secondPlanet;
                }
                else
                {
                    loser = (Planet)firstPlanet;
                    winner = (Planet)secondPlanet;
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = (Planet)firstPlanet;
                loser = (Planet)secondPlanet;
            }
            else
            {
                loser = (Planet)firstPlanet;
                winner = (Planet)secondPlanet;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(x => x.Cost) + loser.Weapons.Sum(x => x.Price));
            string loserName = loser.Name;
            planets.RemoveItem(loser.Name);

            return $"{winner.Name} destructed {loserName}!";
        }

        public string SpecializeForces(string planetName)
        {
            var currPlanet = planets.FindByName(planetName);

            if (currPlanet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (currPlanet.Army.Count == 0)
            {
                throw new InvalidOperationException($"No units available for upgrade!");
            }

            currPlanet.Spend(1.25);
            currPlanet.TrainArmy();

            return $"{planetName} has upgraded its forces!";
        }
    }
}

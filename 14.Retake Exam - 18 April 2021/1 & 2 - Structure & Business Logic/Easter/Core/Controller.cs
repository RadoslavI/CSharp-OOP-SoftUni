using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Dyes;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Eggs;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                bunnies.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunnies.Add(new SleepyBunny(bunnyName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return $"Successfully added dye with power {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return $"Successfully added egg: {eggName}!";
        }

        

        public string ColorEgg(string eggName)
        {
            var egg = eggs.FindByName(eggName);

            List<IBunny> suitableBunnies = bunnies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();
            var printBunnies = suitableBunnies;

            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException(
                    "There is no bunny ready to start coloring!");
            }

            while (suitableBunnies.Count > 0)
            {
                var currBunny = suitableBunnies.First();
                workshop.Color(egg, currBunny);

                if (egg.IsDone())
                {
                    break; 
                }
                if (currBunny.Dyes.Count() == 0)
                {
                    suitableBunnies.Remove(currBunny);
                }
                if (currBunny.Energy == 0)
                {
                    suitableBunnies.Remove(currBunny);
                    bunnies.Remove(currBunny);
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int doneEggs = eggs.Models.Count(x => x.IsDone());
            sb.AppendLine($"{doneEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                if (bunny.Energy > 0)
                {
                    sb.AppendLine($"Name: {bunny.Name}");
                    sb.AppendLine($"Energy: {bunny.Energy}");
                    sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

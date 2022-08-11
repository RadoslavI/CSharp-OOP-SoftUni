using System;
using System.Collections.Generic;

namespace _3_Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();


            while (heroes.Count < N)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (heroType == "Paladin")
                {
                    Paladin paladin = new Paladin(heroName);
                    heroes.Add(paladin);
                }
                else if (heroType == "Druid")
                {
                    Druid druid = new Druid(heroName);
                    heroes.Add(druid);
                }
                else if (heroType == "Warrior")
                {
                    Warrior warrior = new Warrior(heroName);
                    heroes.Add(warrior);
                }
                else if (heroType == "Rogue")
                {
                    Rogue rogue = new Rogue(heroName);
                    heroes.Add(rogue);
                }
                else
                    Console.WriteLine("Invalid hero!");
            }

            int TotalPower = 0;
            foreach (var hero in heroes)
            {
                TotalPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            int BossPower = int.Parse(Console.ReadLine());

            if (TotalPower >= BossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

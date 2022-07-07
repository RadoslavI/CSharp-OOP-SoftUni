using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_Food_Shortage
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                
                if (input.Length == 4)
                {
                    //we have a Citizen
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    IBuyer buyer = new Citizen(id, name, age, birthdate);
                    buyers.Add(name, buyer);
                }
                else if (input.Length == 3)
                {
                    //we have a Rebel
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    IBuyer buyer = new Rebel(name, age, group);
                    buyers.Add(name, buyer);
                } 
            }

            string input2 = Console.ReadLine();

            while (input2 != "End")
            {
                if (buyers.ContainsKey(input2))
                {
                    buyers[input2].BuyFood();
                }
                input2 = Console.ReadLine();
            }
            int totalFood = 0;
            foreach (var buyer in buyers)
            {
                totalFood += buyer.Value.Food;
            }

            Console.WriteLine(totalFood);
        }
    }
}

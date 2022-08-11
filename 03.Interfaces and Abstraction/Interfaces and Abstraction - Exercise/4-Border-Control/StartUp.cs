using System;
using System.Collections.Generic;

namespace _4_Border_Control
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> visitors = new List<IIdentifiable>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();

                if (inputInfo.Length == 2)
                {
                    //We have a robot
                    string model = inputInfo[0];
                    string id = inputInfo[1];

                    IIdentifiable identifiable = new Robot(id, model);
                    visitors.Add(identifiable);
                }
                else if (inputInfo.Length == 3)
                {
                    //we have a citizen
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];

                    IIdentifiable identifiable = new Citizen(id, name, age);
                    visitors.Add(identifiable);
                }

                input = Console.ReadLine();
            }
            
            string endDigits = Console.ReadLine();

            foreach (var item in visitors)
            {
                if (item.ID.EndsWith(endDigits))
                    Console.WriteLine(item.ID);
            }
        }
    }
}

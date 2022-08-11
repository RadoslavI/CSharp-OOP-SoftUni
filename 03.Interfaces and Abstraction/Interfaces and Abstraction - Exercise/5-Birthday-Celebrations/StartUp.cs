using System;
using System.Collections.Generic;

namespace _5_Birthday_Celebrations
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthday> birthdays = new List<IBirthday>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();

                if (inputInfo[0] == "Robot")
                {
                    //We have a robot
                    //string model = inputInfo[0];
                    //string id = inputInfo[1];

                    //IIdentifiable identifiable = new Robot(id, model);
                    //visitors.Add(identifiable);
                }
                else if (inputInfo[0] == "Citizen")
                {
                    //we have a citizen
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdate = inputInfo[4];

                    IBirthday birthdates = new Citizen(id, name, age, birthdate);
                    birthdays.Add(birthdates);
                }
                else if (inputInfo[0] == "Pet")
                {
                    //we have a pet
                    string name = inputInfo[1];
                    string birthdate = inputInfo[2];

                    IBirthday birthdates = new Pet(birthdate, name);
                    birthdays.Add(birthdates);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in birthdays)
            {
                if (item.Birthdate.EndsWith(year))
                    Console.WriteLine(item.Birthdate);
            }
        }
    }
}

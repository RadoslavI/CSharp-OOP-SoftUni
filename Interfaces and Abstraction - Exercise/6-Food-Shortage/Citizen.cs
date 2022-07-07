using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Food_Shortage
{
    public class Citizen : IIdentifiable, IBirthday, IBuyer
    {
        public Citizen(string iD, string name, int age, string birthdate)
        {
            ID = iD;
            Name = name;
            Age = age;
            Birthdate = birthdate;           
        }

        public string ID { get;  }

        public string Name { get; set; }

        public int Age { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}

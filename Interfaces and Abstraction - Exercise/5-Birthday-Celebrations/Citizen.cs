using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Birthday_Celebrations
{
    public class Citizen : IIdentifiable, IBirthday
    {
        public Citizen(string iD, string name, int age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }

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
    }
}

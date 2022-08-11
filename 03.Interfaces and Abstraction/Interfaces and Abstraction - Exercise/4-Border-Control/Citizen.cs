using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Border_Control
{
    public class Citizen : IIdentifiable
    {
        public Citizen(string iD, string name, int age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }

        public string ID { get;  }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}

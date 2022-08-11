using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Food_Shortage
{
    public class Pet : IBirthday
    {
        public Pet(string birthdate, string name)
        {
            Birthdate = birthdate;
            Name = name;
        }

        public string Birthdate {get; set;}
        public string Name {get; set;}

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _5_Birthday_Celebrations
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

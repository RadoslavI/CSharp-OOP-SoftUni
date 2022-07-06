using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int codeNumber) 
            : base(iD, firstName, lastName)
        {
            CodeName = codeNumber;
        }

        public int CodeName { get ; set ; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {ID}");
            sb.AppendLine($"Code Number: {CodeName}");
            return sb.ToString().TrimEnd();
        }
    }
}

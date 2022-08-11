using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public class Engineer : SpecializedSoldier, IEngineer
    {
        public Engineer(int iD, string firstName, string lastName, decimal salary, Corps corps) 
            : base(iD, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get ; set ; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

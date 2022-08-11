using _7_Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7_Military_Elite.Implementations
{
    public class Commando : SpecializedSoldier, ICommando
    {
        public Commando(int iD, string firstName, string lastName, decimal salary, Corps corps) 
            : base(iD, firstName, lastName, salary, corps)
        {
            Missions = new List<IMission>();
        }

        public List<IMission> Missions { get ; set ; }

        public void CompleteMission(string CodeName)
        {
            var mission = Missions.FirstOrDefault(x => x.CodeName == CodeName);
            mission.Status = Status.Finished;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string baseInfo = base.ToString();

            sb.AppendLine(baseInfo);
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

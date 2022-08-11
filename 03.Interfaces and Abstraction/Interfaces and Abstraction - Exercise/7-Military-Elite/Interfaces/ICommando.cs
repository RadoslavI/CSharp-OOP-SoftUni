using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface ICommando : ISpecializedSoldier
    {
        public List<IMission> Missions { get; set; }

        void CompleteMission(string CodeName);
    }
}

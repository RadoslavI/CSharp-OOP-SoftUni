using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface IEngineer : ISpecializedSoldier
    {
        public List<IRepair> Repairs { get; set; }
    }
}

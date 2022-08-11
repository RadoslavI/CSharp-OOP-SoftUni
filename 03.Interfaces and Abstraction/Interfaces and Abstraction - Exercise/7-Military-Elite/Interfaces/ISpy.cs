using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface ISpy : ISoldier
    {
        public int CodeName { get; set; }
    }
}

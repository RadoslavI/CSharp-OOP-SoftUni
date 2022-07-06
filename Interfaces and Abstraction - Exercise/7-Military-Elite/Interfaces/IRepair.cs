using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface IRepair
    {
        public string PartName { get; set; }
        
        public int HoursWorked { get; set; }
    }
}

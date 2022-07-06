using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Military_Elite.Interfaces
{
    public interface ISoldier
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

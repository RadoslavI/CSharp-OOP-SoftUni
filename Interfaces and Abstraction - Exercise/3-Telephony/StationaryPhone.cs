using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
        public string Dial()
        {
            return $"Dialing... {Number}";
        }
    }
}

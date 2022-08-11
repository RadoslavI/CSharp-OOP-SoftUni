using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Telephony
{
    public class Smartphone : ISmartphone
    {
        public Smartphone(string site, string number)
        {
            Site = site;
            Number = number;
        }

        public string Site { get; set; }

        public string Number { get; set; }

        public string Browse()
        {
            return $"Browsing: {Site}!";
        }

        public string Call()
        {
            return $"Calling... {Number}";
        }
    }
}

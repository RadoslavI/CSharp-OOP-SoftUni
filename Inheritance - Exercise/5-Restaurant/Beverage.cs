using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Food
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters { get; set; }

        
    }
}

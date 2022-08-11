using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) : base(name, price)
        {
            Grams = grams;
        }

        public double Grams { get; set; }
    }
}

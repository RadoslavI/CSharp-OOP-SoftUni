﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) : base(name, price)
        {
            Grams = grams;
            Calories = calories;
        }

        public double Grams { get; set; }
        public double Calories  { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private string toppingType;

        public Topping(string toppingType, int grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        public string ToppingType
        {
            get { return toppingType; }
            
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }


        private int grams;

        public int Grams
        {
            get { return grams; }

            private set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public double Calories
        => 2
            * this.Grams
            * modifiers[ToppingType.ToLower()];

    }
}

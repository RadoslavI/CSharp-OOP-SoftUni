using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_PizzaCalories
{
    public class Dough
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private string flourType;

        private string bakingTechnique;

        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            get { return flourType; }

            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value; 
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }

            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }


        public double Calories 
            => 2 
            * this.Grams 
            * modifiers[FlourType.ToLower()] 
            * modifiers[BakingTechnique.ToLower()];

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public virtual bool canEat(string food)
        {
            return true;
        }
        public virtual void Eat (int quantity, string food)
        {
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight = quantity * 1;
            }
        }
    }
}

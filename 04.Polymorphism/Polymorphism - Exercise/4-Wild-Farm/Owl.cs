using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override bool canEat(string food)
        {
            if (food == "Meat")
            {
                return true;
            }
            Console.WriteLine($"Owl does not eat {food}!");
            return false;
        }

        public override void Eat(int quantity, string food)
        {
            Console.WriteLine("Hoot Hoot");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 0.25;
            }
        }

        public override string ToString()
        {
            return $"Owl [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}

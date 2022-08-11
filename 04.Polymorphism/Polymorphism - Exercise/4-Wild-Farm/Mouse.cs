using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override bool canEat(string food)
        {
            if (food == "Vegetable" || food == "Fruit")
            {
                return true;
            }
            Console.WriteLine($"Mouse does not eat {food}!");
            return false;
        }

        public override void Eat(int quantity, string food)
        {
            Console.WriteLine("Squeak");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 0.10;
            }
        }
    }
}

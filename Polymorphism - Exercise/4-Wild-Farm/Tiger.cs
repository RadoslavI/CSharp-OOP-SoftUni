using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }


        public override bool canEat(string food)
        {
            if (food == "Meat")
            {
                return true;
            }
            Console.WriteLine($"Tiger does not eat {food}!");
            return false;
        }

        public override void Eat(int quantity, string food)
        {
            Console.WriteLine("ROAR!!!");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 1.00;
            }
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

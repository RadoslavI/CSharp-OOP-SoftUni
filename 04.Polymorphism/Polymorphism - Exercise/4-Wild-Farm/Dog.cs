using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }

        public override bool canEat(string food)
        {
            if (food == "Meat")
            {
                return true;
            }
            Console.WriteLine($"Dog does not eat {food}!");
            return false;
        }

        public override void Eat(int quantity, string food)
        {
            Console.WriteLine("Woof!");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 0.40;
            }
        }
    }
}

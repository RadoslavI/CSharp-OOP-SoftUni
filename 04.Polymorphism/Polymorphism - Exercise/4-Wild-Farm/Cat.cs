using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override bool canEat(string food)
        {
            if (food == "Vegetable" || food == "Meat")
            {
                return true;
            }
            Console.WriteLine($"Cat does not eat {food}!");
            return false;
        }

        public override void Eat(int quantity, string food)
        {
            Console.WriteLine("Meow");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 0.30;
            }
        }

        public override string ToString()
        {
            return $"Cat [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}

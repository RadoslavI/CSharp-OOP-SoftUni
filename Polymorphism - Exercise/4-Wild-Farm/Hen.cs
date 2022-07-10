using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Wild_Farm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override bool canEat(string food)
        {            
            return true;
        }

        public override void Eat(int quantity, string food)
        {

            Console.WriteLine("Cluck");
            if (canEat(food))
            {
                FoodEaten = quantity;
                Weight += quantity * 0.35;
            }
        }

        public override string ToString()
        {
            return $"Hen [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}

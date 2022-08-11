using System;

namespace _4_PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Topping topping = null;
            Pizza pizza = null;
            Dough dough = null;

            try
            {
                string[] inputPizza = Console.ReadLine().Split();

                string name = inputPizza[1];

                string[] inputDough = Console.ReadLine().Split();
                //string type = inputDough[0];
                string flourType = inputDough[1];
                string bakingTechnique = inputDough[2];
                int weight = int.Parse(inputDough[3]);

                dough = new Dough(flourType, bakingTechnique, weight);
                pizza = new Pizza(name, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingInfo = input.Split();
                    string toppingType = toppingInfo[1];
                    int toppingWeight = int.Parse(toppingInfo[2]);
                    topping = new Topping (toppingType, toppingWeight);

                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}

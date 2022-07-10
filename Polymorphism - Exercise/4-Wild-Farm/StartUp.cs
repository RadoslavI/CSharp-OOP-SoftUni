using System;
using System.Collections.Generic;

namespace _4_Wild_Farm
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();
                string foodName = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);
                
                if (animalInfo[0] == "Cat")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Cat cat = new Cat(name, weight, livingRegion, breed);
                    cat.Eat(foodQuantity, foodName);
                    animals.Add(cat);
                }
                else if (animalInfo[0] == "Dog")
                {
                    //"{Type} {Name} {Weight} {LivingRegion}"
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    Dog dog = new Dog(name, weight, livingRegion);
                    dog.Eat(foodQuantity, foodName);
                    animals.Add(dog);
                }
                else if (animalInfo[0] == "Hen")
                {
                    //"{Type} {Name} {Weight} {WingSize}"
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    Hen hen = new Hen(name, weight, wingSize);
                    hen.Eat(foodQuantity, foodName);
                    animals.Add(hen);
                }
                else if (animalInfo[0] == "Mouse")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    Mouse mouse = new Mouse(name, weight, livingRegion);
                    mouse.Eat(foodQuantity, foodName);
                    animals.Add(mouse);
                }
                else if (animalInfo[0] == "Owl")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    Owl owl = new Owl(name, weight, wingSize);
                    owl.Eat(foodQuantity, foodName);
                    animals.Add(owl);
                }
                else if (animalInfo[0] == "Tiger")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                    tiger.Eat(foodQuantity, foodName);
                    animals.Add(tiger);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var animals = new List<Animal>();

            while (input != "Beast!")
            {
                try
                {
                    if (input == "Cat")
                    {
                        string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(cat);
                    }
                    else if (input == "Dog")
                    {
                        string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(dog);
                    }
                    else if (input == "Frog")
                    {
                        string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        animals.Add(frog);
                    }
                    else if (input == "Kitten")
                    {
                        string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        animals.Add(kitten);
                    }
                    else if (input == "Tomcat")
                    {
                        string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        animals.Add(tomcat);
                    }
                    else 
                    {
                        throw new InvalidOperationException("Invalid type!");                  
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.Name + " " + animal.Age + " " + animal.Gender);
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}

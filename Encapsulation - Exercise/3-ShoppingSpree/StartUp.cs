using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var listOfPeople = new List<Person>();
            var listOfProducts = new List<Product>();
            Product product = null;
            Person person = null;

            try
            {
                //reading people-money pair
                string[] peoplePair = Console.ReadLine().Split(";").ToArray();
                foreach (var pair in peoplePair)
                {
                    //spliting the pair and addind the newly created person to the people list
                    string[] personInfo = pair.Split("=").ToArray();
                    string name = personInfo[0];
                    double money = double.Parse(personInfo[1]);
                    listOfPeople.Add(person = new Person(name, money));
                }
                //doing the same for the products pair on the next read line
                string[] productsPair = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var pair in productsPair)
                {
                    string[] productInfo = pair.Split("=").ToArray();
                    string name = productInfo[0];
                    double cost = double.Parse(productInfo[1]);
                    listOfProducts.Add(product = new Product(name, cost));
                } 
            }
            catch (Exception e)
            {
                //printing the exception message
                Console.WriteLine(e.Message);
                return;
            }
            string command = Console.ReadLine();
            //creating a while loop for adding products to the Person class
            while(command != "END")
            {
                var input = command.Split().ToArray();
                var currPerson  = listOfPeople.Find(x => x.Name == input[0]);
                var currProduct = listOfProducts.Find(x => x.Name == input[1]);
                if (currPerson.Money >= currProduct.Cost)
                {
                    //checking if the current person has enough money, and if yes adds the current product to the list in Person class
                    currPerson.Money -= currProduct.Cost;
                    Console.WriteLine($"{currPerson.Name} bought {currProduct.Name}");
                    currPerson.BagOfProducts.Add(currProduct);
                }
                else
                {
                    //if not prints the according message
                    Console.WriteLine($"{currPerson.Name} can't afford {currProduct.Name}");
                }

                command = Console.ReadLine();
            }
            //foreach loop for every Person in the people list
            foreach (var item in listOfPeople)
            {
                //checks if the current Person has any items the its List<Product>
                if (item.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought ");                    
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {String.Join(", ", item.getProducts())}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bagOfProducts = new List<Product>();

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
        }
        public Person(string name, double money, List<Product> bagOfProducts)
        {
            Name = name;
            Money = money;
            BagOfProducts = bagOfProducts;           
        }

        public string Name 
        { 
            get { return name; } 

            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            } 
        }

        public double Money
        {
            get { return money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
       
        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            set { bagOfProducts = value; }
        }
        
        public List<string> getProducts()
        {
            var productsNames = new List<string>();
            foreach (var item in BagOfProducts)
            {
                productsNames.Add(item.Name);
            }
            return productsNames;
        }
    }
}

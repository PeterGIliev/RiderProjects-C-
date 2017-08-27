using System;
using System.Collections.Generic;

namespace OOP0017ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }
        
        public string Name
        {
            get { return this.name; }
            
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Name)} cannot be empty.");
                }

                this.name = value;
            }
        }
        
        public decimal Money
        {
            get { return this.money; }
            
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

//        public List<Product> BagOfProducts { get; set; }
        

        public void AddProductToTheBag(Product product)
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            
            this.Money -= product.Cost;
            
            this.bagOfProducts.Add(product);
        }
       
    }
}
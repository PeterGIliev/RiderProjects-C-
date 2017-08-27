using System;

namespace OOP0017ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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
        
        public decimal Cost
        {
            get { return this.cost; }
            
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cost cannot be negative");
                }

                this.cost = value;
            }
        }
    }
}
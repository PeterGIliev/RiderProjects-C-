using System;
using System.Collections.Generic;

namespace OOP0017ShoppingSpree
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);
            var peopleList = new Dictionary<string, Person>();
            var productsList = new Dictionary<string, Product>();

            for (int i = 0; i < people.Length; i++)
            {
                var tokens = people[i].Split('=');
                var name = tokens[0];
                var money = decimal.Parse(tokens[1]);

                try
                {
                    var person = new Person(name, money);
                    peopleList.Add(name, person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                } 
            }
            
            var products = Console.ReadLine()
                .Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < products.Length; i++)
            {
                var tokens = products[i].Split('=');
                var name = tokens[0];
                var cost = decimal.Parse(tokens[1]);

                try
                {
                    var product = new Product(name, cost);
                    productsList.Add(name, product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae);
                    throw;
                }  
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var personName = tokens[0];
                var productName = tokens[1];

                Person person = peopleList[personName];
                Product product = productsList[productName];

                try
                {
                    person.AddProductToTheBag(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    throw;
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace ClassPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var listResults = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                
                listResults.Add(person);
            }

            var result = listResults.OrderBy(p => p.Name).ToList();

            foreach (var person in result)
            {
                if (person.Age > 30)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }
    }

    public class Person
    {
        private string name;
        private int age;
        
        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int Age)
        {
            this.name = "No name";
            this.age = Age;
        }
        
        public Person(string Name, int Age)
        {
            this.name = Name;
            this.age = Age;
        }


        public string Name
        {
            get => name;
            set => name = value;
        }


        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}
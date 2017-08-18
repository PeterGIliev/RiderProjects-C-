using System;
using System.Collections.Generic;

namespace OOP0006OldestFamilyMember
{
    internal class Startup
    {
        public static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                
                var person = new Person(name, age);                
                family.AddMember(person);
              
            }
            
            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
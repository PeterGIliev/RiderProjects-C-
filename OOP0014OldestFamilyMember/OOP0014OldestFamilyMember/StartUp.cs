using System;
using System.Collections.Generic;
using System.Reflection;

namespace OOP0014OldestFamilyMember
{
    internal class StartUp
    {
        public static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if(oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            var numberOfMembers = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < numberOfMembers; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);
                
                var person = new Person(name, age);
                
                family.AddMember(person);
            }
            

            var a = family.GetOldestMember().Name;

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
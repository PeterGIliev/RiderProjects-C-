using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OOP0001DefineAClassPerson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var resultList = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var inputName = input[0];
                var inputAge = int.Parse(input[1]);

                var person = new Person(name:inputName, age:inputAge);
                
                resultList.Add(person);

            }
            
//            Type personType = typeof(Person);
//            ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
//            ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
//            ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
//            bool swapped = false;
//            if (nameAgeCtor == null)
//            {
//                nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
//                swapped = true;
//            }
//
//            string name = Console.ReadLine();
//            int age = int.Parse(Console.ReadLine());
//
//            Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
//            Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
//            Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) :(Person)nameAgeCtor.Invoke(new object[] { name, age });
//
//            Console.WriteLine("{0} {1}", basePerson.name, basePerson.age);
//            Console.WriteLine("{0} {1}", personWithAge.name, personWithAge.age);
//            Console.WriteLine("{0} {1}", personWithAgeAndName.name, personWithAgeAndName.age);

            var result = resultList
                .Where(p => p.Age > 30)
                .ToList()
                .OrderBy(p => p.Name);

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
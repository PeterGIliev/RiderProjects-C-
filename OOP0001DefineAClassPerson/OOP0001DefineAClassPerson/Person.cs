using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace OOP0001DefineAClassPerson
{
    public class Person
    {
        
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => this.name;
        public int Age => this.age;

    }
}
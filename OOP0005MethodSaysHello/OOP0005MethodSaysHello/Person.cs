using System;

namespace OOP0005MethodSaysHello
{
    public class Person
    {

        public string personName;

        public Person(string personName)
        {
            this.personName = personName;
        }
        
        public string SayHello(string name)
        {
            return $"{name} says Hello!";
        }
        
    }
}
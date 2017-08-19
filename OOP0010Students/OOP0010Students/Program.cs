using System;
using System.Collections.Generic;

namespace OOP0010Students
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new List<Students>();

            while (input != "End")
            {
                var student = new Students(input)
                {
                    
                };
                
                students.Add(student);
                
                input = Console.ReadLine();
            }

            Console.WriteLine(Students.counter);
        }
    }
}
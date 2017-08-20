using System;
using System.Collections.Generic;

namespace OOP0011UniqueStudentNames
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var student = new Student(input);

                StudentGroup.uniqueStudents.Add(student);
                
                input = Console.ReadLine();
            }

            Console.WriteLine(StudentGroup.uniqueStudents.Count);

        }
    }
}
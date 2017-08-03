using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var test = new Stack<int>();
            test.Push(5);
            test.Push(2);
            test.Push(10);

            var count = test.Count;

            Console.WriteLine(count);
            Console.WriteLine(test.Peek());
            
        }
    }
}
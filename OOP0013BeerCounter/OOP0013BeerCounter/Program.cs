using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP0013BeerCounter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var bottlesIn = tokens[0];
                var bottlesOut = tokens[1];

                input = Console.ReadLine();
            }
        }
    }
}
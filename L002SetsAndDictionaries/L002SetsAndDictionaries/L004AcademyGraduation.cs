using System;
using System.Collections.Generic;
using System.Linq;

namespace L002SetsAndDictionaries
{
    public class L004AcademyGraduation
    {
        public static void main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var score = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList().Average();

                result.Add(name, score);
                
            }

            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} is graduated with {pair.Value}");

            }
        }
    }
}
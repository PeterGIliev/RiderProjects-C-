using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class X007PeriodicTable
    {
        public static void main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    result.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
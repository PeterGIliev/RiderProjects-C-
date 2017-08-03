using System;
using System.Collections.Generic;
using System.Linq;

namespace L002SetsAndDictionaries
{
    public class L003CountSameValuesInArray
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();
            
            var result = new SortedDictionary<decimal, decimal>();

            foreach (decimal element in input)
            {
                if (!result.ContainsKey(element))
                {
                    result[element] = 1;
                }
                else
                {
                    result[element]++;
                }
            }

            foreach (var element in result)
            {
                Console.WriteLine($"{element.Key} - {element.Value} times");
            }
        }
    }
}
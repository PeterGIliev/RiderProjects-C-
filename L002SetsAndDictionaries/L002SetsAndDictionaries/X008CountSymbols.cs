using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class X008CountSymbols
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var result = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!result.ContainsKey(input[i]))
                {
                    result[input[i]] = 1;
                }
                else
                {
                    result[input[i]]++;
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }

        }
    }
}
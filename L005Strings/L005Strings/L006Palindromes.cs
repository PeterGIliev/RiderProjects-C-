using System;
using System.Collections.Generic;
using System.Linq;

namespace L005Strings
{
    public class L006Palindromes
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', ',', '.', '!', '?', ':', ';', '-'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var result = new List<string>();

            foreach (var item in input)
            {
                var itemReversed = String.Join("", item.ToCharArray().Reverse());

                if (item == itemReversed)
                {
                    result.Add(item);
                }
            }
            
            result.Sort();

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
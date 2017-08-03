using System;
using System.Collections.Generic;
using System.Linq;

namespace L002SetsAndDictionaries
{
    public class X006SetsOfElements
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            var n = input[0];
            var m = input[1];

            var firstList = new Queue<int>();
            var secondList = new HashSet<int>();
            var result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var temp = int.Parse(Console.ReadLine());
                
                firstList.Enqueue(temp);
            }
            
            for (int i = 0; i < m; i++)
            {
                var temp = int.Parse(Console.ReadLine());
                
                secondList.Add(temp);
            }

            while (firstList.Count != 0)
            {
                var temp = firstList.Dequeue();
                if (secondList.Contains(temp))
                {
                    result.Add(temp);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
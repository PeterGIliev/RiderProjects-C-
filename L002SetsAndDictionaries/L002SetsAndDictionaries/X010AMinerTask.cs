using System;
using System.Collections.Generic;
using System.Linq;

namespace L002SetsAndDictionaries
{
    public class X010AMinerTask
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, int>();

            while (input != "stop")
            {
                var material = input;
                var quantity = int.Parse(Console.ReadLine());

                if (!result.ContainsKey(material))
                {
                    result.Add(material, quantity);
                }
                else
                {
                    result[material] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
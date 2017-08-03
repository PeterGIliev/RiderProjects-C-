using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace L002SetsAndDictionaries
{
    public class X014PopulationCounter
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var temp = new Dictionary<string, Dictionary<string, int>>();

            while (input != "report")
            {
                var tokens = input.Split('|');
                var city = tokens[0];
                var country = tokens[1];
                var count = int.Parse(tokens[2]);

                if (!temp.ContainsKey(country))
                {
                    temp[country] = new Dictionary<string, int>();
                    temp[country][city] = count;
                }
                else
                {
                    temp[country][city] = count;
                }
                                
                input = Console.ReadLine();
            }

            var result = new Dictionary<string, int>();

            foreach (var item in temp)
            {
                var counter = item.Value.Values.Sum();
                result[item.Key] = counter;
            }

            result = result.OrderByDescending(x => x.Value)
                           .ToDictionary(x => x.Key, y => y.Value);
            
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} (total population: {item.Value})");

                foreach (var subitem in temp[item.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{subitem.Key}: {subitem.Value}");
                }
            }
        }
    }
}
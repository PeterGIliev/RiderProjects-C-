using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography;

namespace L002SetsAndDictionaries
{
    public class X013UserLogs
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var tokens = input.Split(new[] {' ', '='}, StringSplitOptions.RemoveEmptyEntries);

                var IP = tokens[1];
                var user = tokens[5];

                if (!result.ContainsKey(user))
                {
                    result[user] = new Dictionary<string, int>();
                    result[user].Add(IP, 1);
                } 
                else if (result.ContainsKey(user) && !result[user].ContainsKey(IP))
                {
                    result[user].Add(IP, 1);
                }
                else
                {
                    result[user][IP]++;
                }

                input = Console.ReadLine();

            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}:");
                
                var temp = new List<string>();
                
                foreach (var subitem in item.Value)
                {
                    temp.Add($"{subitem.Key} => {subitem.Value}");
                }

                Console.Write(string.Join(", ", temp));
                Console.WriteLine(".");
            }
        }
    }
}
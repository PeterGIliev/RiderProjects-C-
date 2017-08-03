using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace L002SetsAndDictionaries
{
    public class X015LogsAggregator
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var durations = new SortedDictionary<string, int>();
            var IPs = new Dictionary<string, SortedSet<string>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');

                var IP = tokens[0];
                var user = tokens[1];
                var duration = int.Parse(tokens[2]);

                if (!durations.ContainsKey(user))
                {
                    durations[user] = duration;
                    IPs[user] = new SortedSet<string>();
                    IPs[user].Add(IP);
                }
                else
                {
                    durations[user] += duration;
                    IPs[user].Add(IP);
                }
            }

            foreach (var item in durations)
            {
                Console.Write($"{item.Key}: {item.Value} ");
                var forPrint = string.Join(", ", IPs[item.Key]);
                Console.WriteLine($"[{forPrint}]");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X007ValidUsernames
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();

            var pattern = @"(?<=[\s\/\\()])(?<username>[A-Za-z][\w]{2,24})";
            var matches = Regex.Matches(input, pattern);

            var result = new List<string>();
            var length = 0;

            for (int i = 0; i < matches.Count - 1; i++)
            {
                var currentLength = matches[i].Value.Length + matches[i + 1].Value.Length;
                
                if (length < currentLength)
                {
                    result.Clear();
                    length = currentLength;
                    result.Add(matches[i].Value);
                    result.Add(matches[i + 1].Value);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
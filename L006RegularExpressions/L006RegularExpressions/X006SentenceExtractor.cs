using System;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X006SentenceExtractor
    {
        public static void main(string[] args)
        {
            var keyword = Console.ReadLine();
            var input = Console.ReadLine();
            var regex = $@"[^.?!]*(?<=[.?\s!]){keyword}(?=[\s.?!])[^.?!]*[.?!]";

            var matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
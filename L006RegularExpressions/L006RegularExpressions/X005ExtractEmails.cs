using System;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X005ExtractEmails
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"(?:^|\s)((?:[A-Za-z0-9]+[.\-_])*[A-Za-z0-9]+@[A-Za-z]+(?:[.-][A-Za-z]+)+)(?:\.\s)?";

            var matches = Regex.Matches(input, pattern);


//            foreach (Match match in matches)
//            {
//                Console.WriteLine(match);
//            }

            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine(matches[i].Groups[1].Value);
            }
        }
    }
}
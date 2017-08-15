using System;
using System.Text;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X003SeriesOfLetters
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"([a]*)([b]*)([c]*)([d]*)([e]*)([f]*)([g]*)([h]*)([i]*)([j]*)([k]*)([l]*)([m]*)([n]*)([o]*)([p]*)([q]*)([r]*)([s]*)([t]*)([u]*)([v]*)([w]*)([x]*)([y]*)([z]*)";
//            var regex = new Regex(pattern);
            var matches = Regex.Matches(input, pattern);
            var builder = new StringBuilder();
            
            foreach (Match match in matches)
            {
                builder.Append(match.ToString()[0]);
            }

            Console.WriteLine(builder);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X001MatchFullName
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^[A-Z][a-z]+ [A-Z][a-z]+$";
            var rgx = new Regex(pattern);
            
            while (input != "end")
            {
                var match = rgx.Match(input);
                
                if (match.Success)
                {
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace L006RegularExpressions
{
    public class X002MatchPhoneNumber
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^\+359(?<separator>[ -])2\k<separator>\d{3}\k<separator>\d{4}$";
            var rgx = new Regex(pattern);
            var result = new HashSet<string>();
            
            while (input != "end")
            {
                var match = rgx.Match(input);
                
                if (match.Success)
                {
                    result.Add(match.ToString());
                }

                input = Console.ReadLine();
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
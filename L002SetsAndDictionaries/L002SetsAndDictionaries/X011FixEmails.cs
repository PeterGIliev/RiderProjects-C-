using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class X011FixEmails
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var result = new Dictionary<string, string>();

            while (input != "stop")
            {
                var name = input;
                var email = Console.ReadLine();

                if (!email.EndsWith(".uk") && !email.EndsWith(".us"))
                {
                    result.Add(name, email);
                }
                
                input = Console.ReadLine();
            }

            foreach (var element in result)
            {
                Console.WriteLine($"{element.Key} -> {element.Value}");
            }
        }
    }
}
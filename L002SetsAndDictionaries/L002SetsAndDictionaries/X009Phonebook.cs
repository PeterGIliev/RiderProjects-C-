using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class X009Phonebook
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                var temp = input.Split('-');

                phonebook[temp[0]] = temp[1];
                
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (!phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
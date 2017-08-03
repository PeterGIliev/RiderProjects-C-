using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class X005UniqueUsernames
    {
        public static void main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var namesList = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                var user = Console.ReadLine();
                
                namesList.Add(user);
            }

            foreach (var user in namesList)
            {
                Console.WriteLine(user);
            }
        }
    }
}
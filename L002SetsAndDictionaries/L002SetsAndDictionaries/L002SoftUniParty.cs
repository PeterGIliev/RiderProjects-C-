using System;
using System.Collections.Generic;

namespace L002SetsAndDictionaries
{
    public class L002SoftUniParty
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var guestList = new SortedSet<string>();

            while (input != "PARTY")
            {
                guestList.Add(input);
                
                input = Console.ReadLine();
            }
            
            while (input != "END")
            {
                guestList.Remove(input);
                
                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            
            foreach (var ticket in guestList)
            {
                Console.WriteLine(ticket);
            }
        }
    }
}
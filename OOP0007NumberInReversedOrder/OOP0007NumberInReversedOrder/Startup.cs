using System;
using System.Collections.Generic;

namespace OOP0007NumberInReversedOrder
{
    internal class Startup
    {
        public static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            
            var decimalNumber = new DecimalNumber(0);
            decimalNumber.ReverseNumber(inputString);

            Console.WriteLine(decimalNumber.Number);
            
        }
    }
}
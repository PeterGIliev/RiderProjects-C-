using System;

namespace OOP0007LastDigitName
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var num = new Num(null);
            num.TurnDigitToWord(n);

            Console.WriteLine(num.Number);
        }
    }
}
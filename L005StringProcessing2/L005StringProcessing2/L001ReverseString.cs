using System;
using System.Linq;

namespace L005StringProcessing2
{
    public class L001ReverseString
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().Reverse();

            Console.WriteLine(string.Join("", input));
        }
    }
}
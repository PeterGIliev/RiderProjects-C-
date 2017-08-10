using System;
using System.Linq;
using System.Text;

namespace L005Strings
{
    internal class L001ReverseString
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().Reverse();

            var builder = new StringBuilder();

            foreach (var item in input)
            {
                builder.Append(item);
            }
            
            Console.WriteLine(builder);
        }
    }
}
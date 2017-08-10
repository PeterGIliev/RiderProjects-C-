using System;
using System.Text;

namespace L005Strings
{
    public class L002StringLength
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();

            var builder = new StringBuilder();

            if (input.Length < 20)
            {
                builder.Append(input);
                for (int i = input.Length; i < 20; i++)
                {
                    
                    builder.Append("*");
                }
            }
            else
            {
                builder.Append(input.Substring(0, 20));
            }

            Console.WriteLine(builder);
        }
    }
}
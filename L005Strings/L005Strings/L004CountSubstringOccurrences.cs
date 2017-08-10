using System;

namespace L005Strings
{
    public class L004CountSubstringOccurrences
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine();
            var toCompare = Console.ReadLine();

            var counter = 0;
            var length = toCompare.Length;

            for (int i = 0; i < input.Length - length + 1; i++)
            {
                var subPart = input.Substring(i, length).ToLower();

                if (toCompare == subPart)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
using System;
using System.Linq;

namespace L005Strings
{
    public class L007LettersChangeNumbers
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var result = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                var beginningLetter = input[i].Substring(0, 1).ToCharArray();
                var digit = double.Parse(input[i].Substring(1, input[i].Length - 2));
                var endingLetter = input[i].Substring(input[i].Length - 1).ToCharArray();

                if (beginningLetter[0] >= 'A' && beginningLetter[0] <= 'Z')
                {
                    digit = digit / ((int) beginningLetter[0] - 64);
                }
                else
                {
                    digit = digit * ((int) beginningLetter[0] - 96);
                }

                if (endingLetter[0] >= 'A' && endingLetter[0] <= 'Z')
                {
                    digit = digit - ((int) endingLetter[0] - 64);
                }
                else
                {
                    digit = digit + ((int) endingLetter[0] - 96);
                }

                result += digit;
            }
            Console.WriteLine($"{result:F2}");
        }
    }
}
using System;
using System.Linq;
using System.Text;

namespace L005Strings
{
    public class L005SumBigNumbers
    {
        public static void main(string[] args)
        {
            var stringToReplace = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine();

            for (int i = 0; i < stringToReplace.Length; i++)
            {
                string replacer = new string('*', stringToReplace[i].Length);
                text = text.Replace(stringToReplace[i], replacer);
            }

            Console.WriteLine(text);
        }
    }
}
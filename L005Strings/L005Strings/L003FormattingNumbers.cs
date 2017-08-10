using System;
using System.Linq;
using System.Text;

namespace L005Strings
{
    public class L003FormattingNumbers
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
            
            var firstNumber = int.Parse(input[0]);
            var secondNumber = double.Parse(input[1]);
            var thirdNumber = double.Parse(input[2]);

            string myHex = firstNumber.ToString("X");
            string myBinary = Convert.ToString(firstNumber, 2);

            var builder = new StringBuilder();

            // Hexadecimal
            if (myHex.Length < 10)
            {
                builder.Append(myHex);
                for (int i = myHex.Length; i < 10; i++)
                {
                    
                    builder.Append(" ");
                }
            }
            else
            {
                builder.Append(myHex.Substring(0, 10));
            }

            Console.Write($"|{builder}|");

            builder.Clear();
            
            //Binary
            if (myBinary.Length < 10)
            {
                for (int i = myBinary.Length; i < 10; i++)
                {
                    
                    builder.Append("0");
                }
                builder.Append(myBinary);
            }
            else
            {
                builder.Append(myBinary.Substring(0, 10));
            }

            Console.Write($"{builder}|");

            builder.Clear();

            var temp = $"{secondNumber:F2}";
            
            if (temp.Length < 10)
            {
                for (int i = temp.Length; i < 10; i++)
                {
                    
                    builder.Append(" ");
                }
                builder.Append(temp);
            }
            else
            {
                builder.Append(temp.Substring(0, 10));
            }

            Console.Write($"{builder}|");

            builder.Clear();

            temp = $"{thirdNumber:F3}";
            
            if (temp.Length < 10)
            {
                builder.Append(temp);
                
                for (int i = temp.Length; i < 10; i++)
                {
                    
                    builder.Append(" ");
                }
            }
            else
            {
                builder.Append(temp.Substring(0, 10));
            }

            Console.Write($"{builder}|");
        }
    }
}
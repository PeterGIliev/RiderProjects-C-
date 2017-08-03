using System;
using System.Collections.Generic;
using System.Linq;

namespace E001StacksAndQueues
{
    public class A02SimpleCalculator
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToList();
            var n = input.Count;
            var operand = "+";
            var lastValue = 0;
            var count = 0;
    
            for (int i = 0; i < n; i++)
            {
                var temp = input[0];
                
                if (temp == "+" || temp == "-")
                {
                    operand = temp;
                }
                else
                {
                    lastValue = int.Parse(temp);
                    
                    if (operand == "+")
                    {
                        count += lastValue;
                    } else if (operand == "-")
                    {
                        count -= lastValue;
                    }
                }
                
                input.RemoveAt(0);
            }

            Console.WriteLine(count);
        }
    }
}
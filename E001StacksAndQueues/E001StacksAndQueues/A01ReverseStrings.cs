using System;
using System.Collections.Generic;

namespace E001StacksAndQueues
{
    public class A01ReverseStrings
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var repo = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                repo.Push(input[i]);
            }

            var n = repo.Count;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{repo.Pop()}");
            }
        }
    }
}
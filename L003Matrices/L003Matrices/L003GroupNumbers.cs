using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace L003Matrices
{
    public class L003GroupNumbers
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[3][];

            var zero = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var one = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var two = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}
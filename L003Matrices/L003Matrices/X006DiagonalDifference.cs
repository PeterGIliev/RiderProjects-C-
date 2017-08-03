using System;
using System.Collections.Generic;
using System.Linq;

namespace L003Matrices
{
    public class X006DiagonalDifference
    {
        public static void main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (int rows = 0; rows < n; rows++)
            {
                matrix[rows] = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var diagonal1 = 0;
            var diagonal2 = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                diagonal1 += matrix[row][row];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                diagonal2 += matrix[matrix.Length - 1 - row][row];

            }

            Console.WriteLine(Math.Abs(diagonal1 - diagonal2));
        }
    }
}
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace L003Matrices
{
    public class L002MaximumSumOf2x2Submatrix
    {
        public static void main(string[] args)
        {
            var size = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            
            int [][] matrix = new int[int.Parse(size[0])][];
            
            var indexRow = 0;
            var indexCol = 0;
            var maxSum = int.MinValue;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length -1; col++)
                {
                    var currenSum = matrix[row][col]
                                    + matrix[row + 1][col]
                                    + matrix[row][col + 1]
                                    + matrix[row + 1][col + 1];

                    if (currenSum > maxSum)
                    {
                        maxSum = currenSum;
                        indexCol = col;
                        indexRow = row;
                    }
                }
            }

            Console.Write($"{matrix[indexRow][indexCol]} ");
            Console.WriteLine($"{matrix[indexRow][indexCol + 1]}");
            Console.Write($"{matrix[indexRow + 1][indexCol]} ");
            Console.WriteLine($"{matrix[indexRow + 1][indexCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
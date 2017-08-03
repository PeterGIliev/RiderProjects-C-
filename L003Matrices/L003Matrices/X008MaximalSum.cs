using System;
using System.Linq;

namespace L003Matrices
{
    public class X008MaximalSum
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[input[0]][];
            var maxSum = int.MinValue;
            var startRow = 0;
            var startCol = 0;

            for (int row = 0; row < input[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[0].Length - 2; col++)
                {

                    var currentSum = matrix[row][col] + matrix[row + 1][col] + matrix[row + 1][col + 1]
                                     + matrix[row][col + 1] + matrix[row + 2][col + 2] + matrix[row + 2][col]
                                     + matrix[row][col + 2] + matrix[row + 1][col + 2] + matrix[row + 2][col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[startRow][startCol]} {matrix[startRow][startCol + 1]} {matrix[startRow][startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 1][startCol]} {matrix[startRow + 1][startCol + 1]} {matrix[startRow + 1][startCol + 2]}");
            Console.WriteLine($"{matrix[startRow + 2][startCol]} {matrix[startRow + 2][startCol + 1]} {matrix[startRow + 2][startCol + 2]}");
        }
    }
}
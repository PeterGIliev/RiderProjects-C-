using System;
using System.Linq;

namespace L003Matrices
{
    public class X007TwoSquaresInMatrix
    {
        public static void main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new string[input[0]][];
            var counter = 0;

            for (int row = 0; row < input[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[0].Length - 1; col++)
                {
                    if (matrix[row][col] == matrix[row + 1][col]
                        && matrix[row][col] == matrix[row][col + 1]
                        && matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
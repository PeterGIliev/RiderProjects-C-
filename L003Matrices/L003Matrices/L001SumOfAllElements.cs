using System;
using System.Linq;

namespace L003Matrices
{
    public class L001SumOfAllElements
    {
        public static void main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            var rows = int.Parse(matrixSizes[0]);
            
            int [][] matrix = new int[rows][];
            var sum = 0;

            for (int indexRow = 0; indexRow < matrix.Length; indexRow++)
            {
                    matrix[indexRow] = Console.ReadLine()
                        .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    sum += matrix[indexRow].Sum();
            }
            
//            int [,] matrix = new int[rows, columns];
//
//            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
//            {
//                var inputRow = Console.ReadLine()
//                    .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
//                    .Select(int.Parse)
//                    .ToArray();
//                
//                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
//                {
//                    matrix[rowIndex, colIndex] = inputRow[colIndex];
//                }
//            }
//
//            var sum = 0;
//            
//            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
//            {
//                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
//                {
//                    sum += matrix[rowIndex, colIndex];
//                }
//            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(sum);
        }
    }
}
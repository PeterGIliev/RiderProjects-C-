using System;
using System.Linq;

namespace L003Matrices
{
    public class X005MatrixOfPalindromes
    {
        public static void main(string[] args)
        {
            var n = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rowsNumber = n[0];
            var colsNumber = n[1];
            
            var matrix = new string[rowsNumber][];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int rowIndex = 0; rowIndex < rowsNumber; rowIndex++)
            {
                matrix[rowIndex] = new string[colsNumber];
                for (int colIndex = 0; colIndex < colsNumber; colIndex++)
                {
                    matrix[rowIndex][colIndex] = $"{alphabet[rowIndex]}{alphabet[rowIndex + colIndex]}{alphabet[rowIndex]}";
                }
            }

            foreach (var row in matrix)
            
            {
                Console.WriteLine(string.Join(" ", row));
            }
            
        }
    }
}
using System;

namespace L003Matrices
{
    public class L004PascalTriangle
    {
        public static void main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            long[][] pascal = new long[n][];

            for (int row = 1; row < n; row++)
            {
                pascal[row] = new long[row];
                pascal[row][0] = 1;
                pascal[row][pascal[row].Length - 1] = 1;

                    for (int col = 1; col < pascal[row].Length - 1; col++)
                    {
                        pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                    }  
            }
            foreach (var row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
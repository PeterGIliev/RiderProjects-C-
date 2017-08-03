using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace L003Matrices
{
    public class X009RubiksMatrix
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[input[0]][];
            var matrixBench = new int[input[0]][];

            for (int row = 0; row < input[0]; row++)
            {
                var temp1 = new int[input[1]];
                
                for (int i = 0; i < input[1]; i++)
                {

                    temp1[i] = row * input[1] + i + 1;
                }

                matrix[row] = temp1;
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputNew = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var index = int.Parse(inputNew[0]);
                var command = inputNew[1];
                var places = int.Parse(inputNew[2]);

                if (command == "right")
                {
                    while (places > 0)
                    {
                        var temp = matrix[index][matrix[0].Length - 1];
                        for (int col = matrix[0].Length - 1; col > 0; col--)
                        {
                            matrix[index][col] = matrix[index][col - 1];
                        }

                        matrix[index][0] = temp;

                        places--;
                    }
                }
                else if (command == "left")
                {
                    while (places > 0)
                    {
                        var temp = matrix[index][0];

                        for (int col = 0; col < matrix[0].Length - 1; col++)
                        {
                            matrix[index][col] = matrix[index][col + 1];
                        }

                        matrix[index][matrix[0].Length - 1] = temp;

                        places--;
                    }
                }
                else if (command == "up")
                {
                    while (places > 0)
                    {
                        var temp = matrix[0][index];

                        for (int row = 0; row < matrix[0].Length - 2; row++)
                        {
                            matrix[row][index] = matrix[row + 1][index];


                            matrix[matrix[0].Length - 1][index] = temp;

                            places--;
                        }
                    }
                }
                else if (command == "down")
                {
                    while (places > 0)
                    {
                        var temp = matrix[matrix[0].Length - 1][index];

                        for (int row = matrix[0].Length - 1; row > 0; row--)
                        {
                            matrix[row][index] = matrix[row - 1][index];
                        }

                        matrix[0][index] = temp;

                        places--;
                    }
                }
            }
            
            for (int row = 0; row < input[0]; row++)
            {
                var temp1 = new int[input[1]];
                
                for (int i = 0; i < input[1]; i++)
                {

                    temp1[i] = row * input[1] + i + 1;
                }

                matrixBench[row] = temp1;
            }
            
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    if (matrix[rows][cols] == matrixBench[rows][cols])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int benchRows = 0; benchRows < matrix.Length; benchRows++)
                        {
                            for (int benchCols = 0; benchCols < matrix[benchRows].Length; benchCols++)
                            {
                                if (matrixBench[rows][cols] == matrix[benchRows][benchCols])
                                {
                                    Console.WriteLine($"Swap ({rows}, {cols}) with ({benchRows}, {benchCols})");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
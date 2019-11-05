using System;
using System.Collections.Generic;
using System.Linq;

namespace L03MoveDownRightMatrix
{
    public class Program
    {
        private static int[][] results;
        private static int[][] matrix;
        private static int rowMax;
        private static int colMax;
        private static int currentRow;
        private static int currentCol;

        static void Main(string[] args)
        {

            rowMax = int.Parse(Console.ReadLine());
            colMax = int.Parse(Console.ReadLine());

            PopulateMatrix(rowMax);

            currentRow = 0;
            currentCol = 0;

            GetMaxSequence();
        }

        private static void GetMaxSequence()
        {

            results = new int[rowMax][];

            for (int i = 0; i < rowMax; i++)
            {
                results[i] = new int[colMax];
            }
            results[0][0] = matrix[0][0];


            for (int i = 1; i < rowMax; i++)
            {
                results[0][i] = results[0][i - 1] + matrix[0][i];
            }
            for (int i = 1; i < rowMax; i++)
            {
                results[i][0] = results[i - 1][0] + matrix[i][0];
            }



            for (int r = 1; r < rowMax; r++)
            {
                for (int c = 1; c < colMax; c++)
                {
                    var maxElement = Math.Max(results[r - 1][c], results[r][c - 1]) + matrix[r][c];

                    results[r][c] = maxElement;
                }

            }
            //Console.WriteLine("------");
            //Print(results);

            Queue<int[]> coordinates = new Queue<int[]>();
            coordinates.Enqueue(new int[] { currentRow, currentCol });

            while (currentCol < colMax && currentRow < rowMax)
            {
                var maxEl = -1;

                if (currentRow+1==rowMax && currentCol+1==colMax)
                {
                    break;
                }

                else if (currentRow+1==rowMax)
                {
                    maxEl= results[currentRow][currentCol + 1];
                    coordinates.Enqueue(new int[] { currentRow, currentCol + 1 });
                    currentCol++;
                }
                else if (currentCol+1==colMax)
                {
                    maxEl= results[currentRow + 1][currentCol];
                    coordinates.Enqueue(new int[] { currentRow + 1, currentCol });
                    currentRow++;
                }
                else
                {
                    var down = results[currentRow + 1][currentCol];
                    var right = results[currentRow][currentCol + 1];
                    maxEl = Math.Max(down, right);

                    if (maxEl == down)
                    {
                        coordinates.Enqueue(new int[] { currentRow + 1, currentCol });
                        currentRow++;
                    }
                    else
                    {
                        coordinates.Enqueue(new int[] { currentRow, currentCol + 1 });
                        currentCol++;
                    }
                }
            }

            Console.WriteLine(string.Join(" ",coordinates.Select(a=> $"[{a[0]}, {a[1]}]")));
        }

        private static void PopulateMatrix(int size)
        {
            matrix = new int[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(int.Parse)
                    .ToArray();
            }
        }
        private static void Print(int[][] matrix)
        {
            for (int i = 0; i < rowMax; i++)
            {
                Console.WriteLine(string.Join(" ", results[i]));
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L02_PathFinding
{
    class Program
    {
        private static int rowMax;
        private static int colMax;

        private static char[][] matrix;
        private static List<char> roads = new List<char>();
        static void Main(string[] args)
        {
            ReadMatrix();


            FindPaths(0, 0, 'S');



        }

        private static void FindPaths(int row, int col, char direction)
        {

            //Console.WriteLine();
            //PrintMatrix(matrix);
            if (!IsInBounds(row, col))
            {
                return;
            }

            roads.Add(direction);

            if (IsExit(row, col))
            {
                PrintPath();
            }

            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                FindPaths(row + 1, col, 'D');

                //a bit strange.... 
                Unmark(row, col);
            }


            //why is this... accomplished? 
            //to remove it from the map collection
            //in thee unmark it is removed from the matrix itself
            //below we remove it from the map! 
            roads.RemoveAt(roads.Count - 1);

        }

        private static void Mark(int row, int col)
        {
            matrix[row][col] = 'v';
        }

        private static void Unmark(int row, int col)
        {
            matrix[row][col] = '-';
        }

        private static bool IsFree(int row, int col)
        {
            return matrix[row][col] == '-';
        }

        private static bool IsVisited(int row, int col)
        {
            //mistake: here i thought they would be marked on the map (matrix) 
            //return matrix[row][col] == 'R' ||
            //       matrix[row][col] == 'L' ||
            //       matrix[row][col] == 'U' ||
            //       matrix[row][col] == 'D';

            return matrix[row][col] == 'v';


        }

        private static bool IsExit(int row, int col)
        {
            return matrix[row][col] == 'e';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", roads.Skip(1)));
        }

        private static bool IsInBounds(int row, int col)
        {

            return row >= 0 && row <= rowMax - 1 &&
                   col >= 0 && col <= colMax - 1
                   && !IsVisited(row, col);
        }

        private static void ReadMatrix()
        {
            rowMax = int.Parse(Console.ReadLine());
            colMax = int.Parse(Console.ReadLine());

            matrix = new char[rowMax][];

            for (int i = 0; i < rowMax; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }


        }

        private static void PrintMatrix(char[][] matrixToPrint)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrixToPrint.Length; i++)
            {
                sb.AppendLine(string.Join("", matrixToPrint[i]));
            }


            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}

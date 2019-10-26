using System;
using System.Linq;

namespace L01_Recursive_ArraySum
{
    public class Program
    {
        static void Main()
        {

            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            int[] vector = new int[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = arr[i];
            }


            GenerateAllNCombinations(arr, vector, n, arr.Length);



        }

        private static void GenerateAllNCombinations(int[] set, int[] vector, int index, int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateAllNCombinations(set, vector, index+1, i+1);
                }
            }

        }

    
    private static void GenerateVector(int[] arr, int index)
    {
        if (index > arr.Length - 1)
        {
            Console.WriteLine(string.Join("", arr));
            return;
        }

        for (int i = 0; i <= 1; i++)
        {
            arr[index] = i;
            GenerateVector(arr, index + 1);
        }

    }

    private static void DrawFigure(int n)
    {
        if (n <= 0)
        {
            return;
        }

        Console.WriteLine(new string('*', n));
        DrawFigure(n - 1);

        Console.WriteLine(new string('#', n));

    }

    //2nd Recursive Factorial 
    private static int GetFactioral(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        return (n * GetFactioral(n - 1));

    }

    //1st Sum Of Array
    private static int GetSumOfArray(int[] array)
    {
        if (array.Length == 0)
        {
            return 0;
        }

        return array[0] + GetSumOfArray(array.Skip(1).ToArray());
    }
}
}

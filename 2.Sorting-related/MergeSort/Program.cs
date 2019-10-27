using System;
using System.Linq;

namespace L01_Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = 
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Mergesort<int>.Sort(numbers);

            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_Subset_Problem_without_repeats
{
    public class Program
    {
        private static int[] numbers;
        static void Main()
        {
            numbers = new int[] { 3, 5, 1, 4, 2 };
            int number = int.Parse(Console.ReadLine());

            var result = GetSetIfPossible(number);
            Console.WriteLine(result);
        }

        private static bool GetSetIfPossible(int number)
        {
            Dictionary<int, int> numberToPrevious = new Dictionary<int, int>();

            numberToPrevious.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var allKeys = numberToPrevious.Keys;
                var currentNum = numbers[i];

                foreach (var val in allKeys.ToList())
                {
                    //val is the step to the newSum
                    //newsum is the key (or the last value) 
                    var newSum = currentNum + val;
                    if (!numberToPrevious.ContainsKey(newSum))
                    {
                        numberToPrevious.Add(newSum, val);
                    }

                }

            }

            var result = new List<int>();

            if (numberToPrevious.ContainsKey(number))
            {
                var current = number;
                var previous = current - numberToPrevious[number];

                while (current != 0)
                {
                    result.Add(previous);
                    current -=previous ;
                    previous = numberToPrevious[current];

                    if (previous==0)
                    {
                        result.Add(current);
                        current = 0;
                    }
                }

                
                Console.WriteLine(string.Join(" ", result));

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P04EgyptianFractions
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tokens = Console.ReadLine()
                .Split('/')
                .Select(int.Parse)
                .ToArray();

            int numerator = tokens[0];
            int denominator = tokens[1];
            int initialNum = numerator;
            int initialDen = denominator;
            

            int currentDenominator = 2;
            int currentNominator = 1;

            int count = 2;

            var result = new List<string>();


            if (numerator>= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }


            while (numerator != 0)
            {
                int rightNumerator = denominator * currentNominator;

                int leftNumerator = numerator * currentDenominator;

                if (rightNumerator > leftNumerator)
                {

                    count++;
                    currentDenominator = count;
                    continue;
                }

                leftNumerator -= rightNumerator;
                numerator = leftNumerator;

                result.Add($"1/{currentDenominator}");

                denominator = currentDenominator * denominator;

                count++;
                currentDenominator = count;
            }


            Console.WriteLine($"{initialNum}/{initialDen} = {string.Join(" + ",result)}");
        }
    }
}

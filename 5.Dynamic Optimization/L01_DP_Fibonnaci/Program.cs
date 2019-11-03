using System;

namespace L01_DP_Fibonnaci
{
    public class Program
    {

        public static long[] solutions;
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            solutions = new long[number+1];

            long answer = GetFibbonaci(number);

            Console.WriteLine(answer);
        }

        public static long GetFibbonaci(int number)
        {
            if (solutions[number] != 0)
            {
                return solutions[number];
            }

            if (number == 1 || number == 2)
            {    
                return 1;
            }

            //here just separate the result into a variable and save it in solutions array, for the future!
            long result = GetFibbonaci(number - 1) + GetFibbonaci(number - 2);

            solutions[number] = result;

            return result ;
            
            //alternative is just returning the results always
            //return GetFibbonaci(number-1)+ GetFibbonaci(number-2);

        }
    }
}

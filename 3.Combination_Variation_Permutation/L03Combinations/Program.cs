using System;
using System.Linq;

namespace L03Combinations
{
    class Program
    {
        private static int bound;
        private static int length;
        private static char[] temp;
        private static char[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
               .Split(' ')
               .Select(char.Parse)
               .ToArray();


            bound = int.Parse(Console.ReadLine());
            temp = new char[bound];
            length = elements.Length;
            GetCombination(0, 0);
            Console.WriteLine(GetCombinationsCount(length,bound));

        }

        static void GetCombination(int index, int start)
        {
            if (index >= bound)
            {
                Console.WriteLine(string.Join(" ", temp));
            }
            
            else
            {
                for (int i = start; i < length; i++)
                {
                    temp[index] = elements[i];

                    //without repetition
                    GetCombination(index + 1, i + 1);

                    //with repetition
                    //GetCombination(index + 1, i);
                }
            }
        }


        static int GetCombinationsCount(int length, int bound)
        {
            int belowNumber = GetFactoriel(bound) / GetFactoriel(length - bound);
            
            return GetFactoriel(length) / belowNumber;
        }

        static int GetFactoriel(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * GetFactoriel(number - 1);
        }
    }
}

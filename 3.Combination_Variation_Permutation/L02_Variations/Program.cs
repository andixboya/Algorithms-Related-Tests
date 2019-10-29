using System;
using System.Linq;

namespace L02_Variations
{
    class Program
    {
        public static char[] elements;
        public static char[] variation;
        public static bool[] used;


        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            int maxCount = int.Parse(Console.ReadLine());

            used = new bool[elements.Length];
            variation = new char[maxCount];

            GetVariations(0);

            Console.WriteLine(GetVariationsCount(elements.Length,maxCount));
        }

        static void GetVariations(int index)
        {
            if (index >= variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    //if this is documented , it adds variations with repetition 
                    if (used[i] is false)
                    {
                        used[i] = true;

                        variation[index] = elements[i];
                        GetVariations(index + 1);

                        used[i] = false;
                    }
                }
            }
        }

        static long GetVariationsCount(int length, int boundary)
        {
            int belowPart = length - boundary;

            return GetFactoriel(length) / GetFactoriel(belowPart);
        }

        static int GetFactoriel(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number* GetFactoriel(number-1);
        }
    }
}

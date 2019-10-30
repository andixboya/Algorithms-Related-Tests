using System;
using System.Collections.Generic;
using System.Linq;

namespace L01Permutations
{

    public static class Program
    {
        public static char[] elements;
        public static char[] temp;
        public static bool[] used;


        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            used = new bool[elements.Length];
            temp = new char[elements.Length];

            PermuteWithoutRepetitionWithTempArr(0);
            //PermutationWithSwap(0);
            //PermutationWithRepetition(0);

        }

        private static void PermutationWithSwap(int index)
        {

            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }

            else
            {
                PermutationWithSwap(index + 1);
                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    PermutationWithSwap(index + 1);
                    Swap(index, i);

                }

            }

        }

        //***** 
        private static void PermutationWithRepetition(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        PermutationWithRepetition(index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);

                    }

                }
            }

        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }

        private static void PermuteWithoutRepetitionWithTempArr(int index)
        {
            //for break;
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", temp));
            }

            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (used[i] is false)
                    {
                        used[i] = true;

                        temp[index] = elements[i];
                        PermuteWithoutRepetitionWithTempArr(index + 1);
                        //here i ... lol
                        used[i] = false;
                    }

                }
            }
        }
    }

}

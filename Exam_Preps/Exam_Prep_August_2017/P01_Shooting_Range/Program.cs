using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_Shooting_Range
{
    public class Program
    {
        private static int[] elements;
        private static int numberToSearchFor;
        public static int[] temp;
        public static bool[] used;



        private static HashSet<string> answers = new HashSet<string>();
        static void Main()
        {

            elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            numberToSearchFor = int.Parse(Console.ReadLine());
            temp = new int[elements.Length];
            used = new bool[elements.Length];

            PermutationWithRepetition(0);
            //var answers = combinations.Where(kvp => kvp.Key == numberToSearchFor).ToDictionary(x => x.Key, y => y.Value);

        }



        private static void PermutationWithRepetition(int index)
        {
            if (index >= elements.Length)
            {
                var current = 0;
                for (int i = 0; i < elements.Length; i++)
                {
                    current = current + ((i + 1) * elements[i]);

                    if (current > numberToSearchFor)
                    {
                        break;
                    }

                    if (current == numberToSearchFor)
                    {

                        var x = string.Join(" ", elements.Take(i + 1));
                        if (!answers.Contains(x))
                        {
                            answers.Add(x);
                            Console.WriteLine(x);
                        }
                        
                    }


                }

            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        used[i] = true; ;
                        PermutationWithRepetition(index + 1);
                        Swap(index, i);
                        used[i] = false;
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



    }
}

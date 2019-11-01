using System;
using System.Collections.Generic;
using System.Linq;

namespace P00Words_From_Sorting
{
    class Program
    {
        public static char[] elements;
        public static int count;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().ToCharArray();
            GetElements(0);
            Console.WriteLine(count);
        }

        public static void GetElements(int index)
        {
            HashSet<char> symbols = new HashSet<char>();

            foreach (var el in elements)
            {
                symbols.Add(el);
            }
            if (symbols.Count==elements.Count())
            {
                count= Factorial(symbols.Count);
                return;
            }
            Permute(0);    
        }

        public static void Permute(int index)
        {
            if (index >= elements.Length)
            {
             //here we add a condition so that each symbol will not be repeated sequentially
                for (int i = 0; i < elements.Length-1; i++)
                {
                    var current = elements[i];
                    var next = elements[i + 1];
                    if (current==next)
                    {
                        return;
                    }
                }

                //here we just replace the print() with count++

                count++;
                //Console.WriteLine(string.Join(" ", elements));
            }

            else
            {

                HashSet<int> swapped = new HashSet<int>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);

                        swapped.Add(elements[i]);
                    }


                }

            }
        }

        public static int Factorial(int number)
        {
            int num = 1;
            for (int i = 1; i <= number; i++)
            {
                num *= i;
            }

            return num;
        }

        private static void Swap(int index, int i)
        {
            var temp = elements[index];
            elements[index] = elements[i];
            elements[i] = temp;
        }
    }
}

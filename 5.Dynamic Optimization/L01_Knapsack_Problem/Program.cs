using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L01_Knapsack_Problem
{
    public class Program
    {
        public static int[,] valueMatrix;
        public static bool[,] isTakenMatrix;
        static void Main(string[] args)
        {
            int totalCapacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            List<Item> allItems = new List<Item>();

            while (input != "end")
            {
                string[] tokens = input.Split(' ');
                Item current = new Item()
                {
                    Name = tokens[0]
                    ,
                    Weight = int.Parse(tokens[1])
                    ,
                    Value = int.Parse(tokens[2])
                };

                allItems.Add(current);

                input = Console.ReadLine();
            }

            InitialPopulationOfMatricies(totalCapacity, allItems);

            for (int i = 0; i < allItems.Count; i++)
            {
                var currentItemIndex = i + 1;
                var currentItem = allItems[i];

                //this should start from 1, i think? 
                //total capacity +1 , but why? 
                for (int currentCapacity = 1; currentCapacity <= totalCapacity; currentCapacity++)
                {
                    var excluding = valueMatrix[currentItemIndex - 1, currentCapacity];

                    //forgot to make this check! 
                    if (currentItem.Weight > currentCapacity)
                    {
                        valueMatrix[currentItemIndex, currentCapacity] = excluding;
                        continue;
                    }

                    //note: how do we know its on the previous.... and not on a lower value(capacity index?)
                    //( because it filters from 0 it takes the minimum!!!!)
                    var including = currentItem.Value + valueMatrix[currentItemIndex - 1, currentCapacity - currentItem.Weight];
                    if (including > excluding)
                    {
                        valueMatrix[currentItemIndex, currentCapacity] = including;
                        isTakenMatrix[currentItemIndex, currentCapacity] = true;
                    }
                    else
                    {
                        valueMatrix[currentItemIndex, currentCapacity] = excluding;

                    }
                }

            }

            //Print();
            //Console.WriteLine(valueMatrix[allItems.Count, totalCapacity]);
            List<Item> resultItems = new List<Item>();

            int initialItemIndex = allItems.Count;
            int availableCapacity = totalCapacity;

            for (int i = totalCapacity; i >= 0; i--)
            {
                for (int j = initialItemIndex; j >= 0; j--)
                {
                    if (isTakenMatrix[j, i] == true)
                    {
                        int itemIndex = j - 1;
                        if (availableCapacity > allItems[itemIndex].Weight)
                        {
                            availableCapacity -= allItems[itemIndex].Weight;
                            resultItems.Add(allItems[itemIndex]);
                            initialItemIndex--;
                            break;
                        }

                    }

                }
                if (availableCapacity <= 0)
                {
                    break;
                }

            }

            PrintResult(totalCapacity, allItems, resultItems);
        }

        private static void PrintResult(int totalCapacity, List<Item> allItems, List<Item> result)
        {
            var totalWeight = result.Select(i => i.Weight).Sum();
            var totalValue = valueMatrix[allItems.Count, totalCapacity];
            var collectionOfItems = string.Join(Environment.NewLine, result.Select(i => i.Name).OrderBy(i => i));


            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            Console.WriteLine(collectionOfItems);
        }

        private static void PrintMatricies()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbTwo = new StringBuilder();
            for (int i = 0; i < valueMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < valueMatrix.GetLength(1); j++)
                {
                    sb.Append(valueMatrix[i, j]);
                    sbTwo.Append(isTakenMatrix[i, j]);

                }
                sb.AppendLine();
                sbTwo.AppendLine();
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine(sbTwo.ToString());
        }

        private static void InitialPopulationOfMatricies(int totalCapacity, List<Item> allItems)
        {
            valueMatrix = new int[allItems.Count + 1, totalCapacity + 1];

            isTakenMatrix = new bool[allItems.Count + 1, totalCapacity + 1];


            for (int i = 0; i < totalCapacity; i++)
            {
                valueMatrix[0, i] = 0;
            }
            for (int i = 0; i < allItems.Count; i++)
            {
                valueMatrix[i, 0] = 0;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

    }


}

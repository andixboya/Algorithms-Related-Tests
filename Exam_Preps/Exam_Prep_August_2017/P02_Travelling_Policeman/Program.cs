using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_Travelling_Policeman
{
    public class Program
    {
        public static int[,] valueMatrix;
        public static bool[,] isTakenMatrix;
        static void Main(string[] args)
        {
            int fuel = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            List<Item> allItems = new List<Item>();


            while (input != "End")
            {
                string[] tokens = input.Split(',').ToArray();
                var streetName = tokens[0];
                var carDmg = int.Parse(tokens[1]);
                var pokeCount = int.Parse(tokens[2]);
                var streetLength = int.Parse(tokens[3]);

                var currentPokeValue = pokeCount * 10 - carDmg;

                Item current = new Item
                {
                    Name = streetName,
                    Value = currentPokeValue,
                    Damage = carDmg,
                    Count = pokeCount,
                    Length = streetLength
                };
                allItems.Add(current);
                input = Console.ReadLine();
            }



            InitialPopulationOfMatricies(fuel, allItems);

            for (int i = 0; i < allItems.Count; i++)
            {

                var currentItemIndex = i + 1;
                var currentItem = allItems[i];

                
                for (int currentCapacity = 1; currentCapacity <= fuel; currentCapacity++)
                {
                    var excluding = valueMatrix[currentItemIndex - 1, currentCapacity];
                    var including = -1;


                    if (currentItem.Length <= currentCapacity)
                    {
                        //this check matters a lot beacuse it will mess up the indidices!!!
                        
                        var prev = valueMatrix[currentItemIndex - 1, currentCapacity - currentItem.Length];
                        including = currentItem.Value + prev;

                    }

                    //it matters if its within hre or the above body! 
                    if (including > excluding)
                    {
                        valueMatrix[currentItemIndex, currentCapacity] = including;
                        isTakenMatrix[currentItemIndex, currentCapacity] = true;
                    }

                    else
                    {
                        valueMatrix[currentItemIndex, currentCapacity] = excluding;
                        isTakenMatrix[currentItemIndex, currentCapacity] = true;
                    }



                }

            }

            //PrintMatricies();

            List<Item> resultItems = new List<Item>();

            var tempCap = fuel;

            for (int i = allItems.Count; i > 0; i--)
            {
                if (!isTakenMatrix[i, tempCap])
                {
                    continue;
                }
                var item = allItems[i - 1];
                resultItems.Add(item);
                tempCap = tempCap - item.Length;
            }


            ;


            PrintResult(fuel, allItems, resultItems);

        }


        
        private static void PrintResult(int totalCapacity, List<Item> allItems, List<Item> result)
        {
            StringBuilder sb = new StringBuilder();
            result.Reverse();
            var totalDmgDealth = result.Select(i => i.Damage).Sum();
            var totalPokemons = result.Select(p => p.Count).Sum();
            var fuelLeft = totalCapacity - result.Select(s => s.Length).Sum();
            var streets = string.Join(" -> ", result.Select(s => s.Name));



            sb.AppendLine(streets);
            sb.AppendLine($"Total pokemons caught -> {totalPokemons}");
            sb.AppendLine($"Total car damage -> {totalDmgDealth}");
            sb.AppendLine($"Fuel Left -> {fuelLeft}");
            Console.WriteLine(sb.ToString().TrimEnd());

        }

        private static void PrintMatricies()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbTwo = new StringBuilder();
            for (int i = 0; i < valueMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < valueMatrix.GetLength(1); j++)
                {
                    sb.Append($"{valueMatrix[i, j]} ");
                    sbTwo.Append($"{isTakenMatrix[i, j]} ");

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
        public int Value { get; set; }

        public int Count { get; set; }

        public int Damage { get; set; }

        public int Length { get; set; }
    }
}

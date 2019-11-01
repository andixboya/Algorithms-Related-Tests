using System;
using System.Collections.Generic;
using System.Linq;

namespace P01Fraction_Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] parts = Console.ReadLine().Split(':').ToArray();


            double capacity = double.Parse(parts[1]);

            parts = Console.ReadLine().Split(':');
            int countOfItems = int.Parse(parts[1]);

            Dictionary<string, Item> byItem = new Dictionary<string, Item>();

            for (int i = 0; i < countOfItems; i++)
            {
                string input = Console.ReadLine();
                string[] partitions = input.Split(new char[] { ' ','>','-'})
                        .Where(x=> !string.IsNullOrWhiteSpace(x)).ToArray();

                double price = double.Parse(partitions[0]);
                double weight = double.Parse(partitions[1]);
                Item current = new Item(price, weight);

                if (!byItem.ContainsKey(input))
                {
                    byItem[input] = current;
                }
                else
                {
                    byItem[input] = current;
                }
            }

            byItem = byItem
                .OrderByDescending(x => x.Value.Ratio)
                .ToDictionary(x => x.Key, y => y.Value);


            double totalPrice = 0;

            foreach (var item in byItem)
            {
                if (capacity == 0)
                {
                    break;
                }
                double takeRatio = 1;


                var current = item.Value;

                if (current.Weight > capacity)
                {
                    takeRatio = capacity / current.Weight;
                }
                capacity -= takeRatio * current.Weight;
                totalPrice += takeRatio * current.Price;

                if (takeRatio==1)
                {
                    Console.WriteLine($"Take {takeRatio*100}% of item with price {current.Price:f2} and weight {current.Weight:f2}");
                }
                else
                {
                    Console.WriteLine($"Take {takeRatio * 100:f2}% of item with price {current.Price:f2} and weight {current.Weight:f2}");
                }
                
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");

        }

    }

    public class Item
    {
        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
        public double Price { get; set; }

        public double Weight { get; set; }

        public double Ratio => this.Price / this.Weight;
    }
}

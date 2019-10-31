namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {

        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            // TODO
            Queue<int> coinsAsQueue = new Queue<int>(coins.OrderByDescending(x => x));
            Dictionary<int, int> result = new Dictionary<int, int>();

            var current = coinsAsQueue.Peek();
            while (coinsAsQueue.Count > 0)
            {
                //ah... the optimization! 
                if (targetSum < current)
                {
                    coinsAsQueue.Dequeue();
                    current = coinsAsQueue.Peek();
                    continue;
                }
                else
                {
                    int countToAdd = targetSum / current;
                    targetSum %= current;

                    if (!result.ContainsKey(current))
                    {
                        result[current] = 0;
                    }
                    result[current]+=countToAdd;

                    if (targetSum == 0)
                    {
                        break;
                    }
                    coinsAsQueue.Dequeue();
                    current = coinsAsQueue.Peek();
                }


            }


            if (targetSum > 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace P02Processor_Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] parts = Console.ReadLine().Split(':');
            int maxCount = int.Parse(parts[1]);

            Dictionary<int, List<int>> deadlineToValue = new Dictionary<int, List<int>>();
            List<Item> byOrderOfInput = new List<Item>();
            Dictionary<int, int> numberOfMissionToDeadline = new Dictionary<int, int>();

            for (int i = 0; i < maxCount; i++)
            {
                string input = Console.ReadLine();
                int[] nums = input
                    .Split('-')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(int.Parse)
                    .ToArray();
                int value = nums[0];
                int deadline = nums[1];

                if (!deadlineToValue.ContainsKey(deadline))
                {
                    deadlineToValue.Add(deadline, new List<int>());
                }
                numberOfMissionToDeadline[i + 1] = deadline;

                byOrderOfInput.Add(new Item(value, deadline));
                deadlineToValue[deadline].Add(value);
            }

            var biggestPeriod = deadlineToValue
                .OrderByDescending(x => x.Key)
                .Select(x => x.Key)
                .FirstOrDefault();

            int current = 1;
            Dictionary<int, HashSet<int>> result = new Dictionary<int, HashSet<int>>();

            while (maxCount >= current && biggestPeriod >= current)
            {

                var sorted = byOrderOfInput
                    .Where(x => x.DeadLine <= biggestPeriod && x.IsMarked == false)
                    .OrderByDescending(y => y.Value).ToList();

                Item maxItem = byOrderOfInput
                    .Where(x => x.DeadLine <= biggestPeriod && x.IsMarked == false)
                    .OrderByDescending(y => y.Value).FirstOrDefault();

                var index = byOrderOfInput.IndexOf(maxItem);

                if (!result.ContainsKey(index+1))
                {
                    result[index+1] = new HashSet<int>();
                }
                result[index+1].Add(maxItem.Value);

                maxItem.IsMarked = true;
                current++;
            }



            var actual = result.OrderBy(x => numberOfMissionToDeadline[x.Key])
                .ThenByDescending(x => x.Value.Sum());

            var tasks = actual.Select(i => i.Key);

            var totalValue = actual
                .SelectMany(i => i.Value)
                .Sum();

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", tasks)}");
            Console.WriteLine($"Total value: {totalValue}");
        }


        public class Item
        {

            public Item(int value, int period)
            {
                this.Value = value;
                this.DeadLine = period;
                this.IsMarked = false;
            }

            public int Value { get; set; }

            public bool IsMarked { get; set; }

            public int DeadLine { get; set; }

        }
    }
}

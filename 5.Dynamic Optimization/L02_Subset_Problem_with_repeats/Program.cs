using System;

namespace L02_Subset_Problem_with_repeats
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 3, 5, 2 };
            var targetSum = 17;

            //its targetSum + 1 , because 1 is the minimal iteration!?+ the 0 index?
            var possibleSums = new bool[targetSum + 1];
            //this is a bit like the enqueue loop (or bfs , exactly!) 
            //but instead you get an array and mark the indicies, which 
            //then are used for further steps for continuation
            //if they are not overalpped, it will just iterate through the options
            //why possible.sums+ 1 => because of the 0
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                //it first enters each of the following numbers (3 5 2)
                //marks 3 5 2 and on each of these iteration it again marks the 3+ 3 , 3+5 ...)
                //until  the targetSum is marked!
                
                if (possibleSums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var newSum = sum + numbers[i];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }

                }

            }
            Console.WriteLine(possibleSums[targetSum]);


            while (targetSum != 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var sum = targetSum - numbers[i];

                    //then it uses the bool array, to check if the sum is part of the answer....
                    //and again it iterates through all of the indicies
                    if (sum >= 0 && possibleSums[sum])
                    {
                        Console.Write(numbers[i] + " ");
                        targetSum = sum;
                    }

                }

            }




        }
    }
}

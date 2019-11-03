using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_LIS
{
    class Program
    {
        private static int[] seq;
        private static int[] len;
        //we`ll need this , to keep a reference between the answer-indicies
        private static int[] prev;


        static void Main()
        {

            seq = Console.ReadLine()
                .Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(int.Parse)
                .ToArray();

            len = new int[seq.Length];

            prev = new int[seq.Length];


            var result = GetMaxSubsequence();
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] GetMaxSubsequence()
        {
            int maxLen = 0;
            int lastIndex = -1;
            for (int rightMost = 0; rightMost < seq.Length; rightMost++)
            {

                //for each element to the right, the length is set to 1 and
                //the previous is set to non existent
                len[rightMost] = 1;
                prev[rightMost] = -1;

                //right-most 
                var currentEl = seq[rightMost];

                //note: **** in each count prev holds our answers to the longest and it is rewritten!
                for (int leftMost = 0; leftMost < rightMost; leftMost++)
                {
                    var previousEl = seq[leftMost];

                    //if there is an element, which is smaller than the current rightMost
                    //we`ll add +1 to the result
                    //why +1?=> because otherwise it would be from another sequence
                    if ((previousEl < currentEl) && (len[leftMost] + 1 > len[rightMost]))
                    {
                        //you overwrite only the value of the right pointer!
                        len[rightMost] = len[leftMost] + 1;
                        prev[rightMost] = leftMost;
                    }
                }


                //and here we rewrite if the rightMostLeng is bigger than the previous rightMost
                //for each iteration  (we check if the last index is not longest!

                if (len[rightMost] > maxLen)
                {
                    maxLen = len[rightMost];
                    lastIndex = rightMost;
                }
            }

            return RestoreLIS(lastIndex);
        }

        public static int[] RestoreLIS(int lastIndex)
        {
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                //from seq we take the value which we need
                longestSeq.Add(seq[lastIndex]);
                //from prev we keep a reference to each previous element to the  last
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();
            return longestSeq.ToArray();
        }


       
    }
}

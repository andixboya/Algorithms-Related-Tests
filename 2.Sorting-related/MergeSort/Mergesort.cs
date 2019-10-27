
namespace L01_Merge_Sort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mergesort<T>
        where T : IComparable
    {

        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            //if the middle is both beginning and end, then it does no actions! 
            //this is the break to the infinite loop 
            
            if (lo >= hi)
            {
                return;
            }

            int mid = (lo + hi) / 2;

            //here it cuts the boundaries either left or right into half, until they are equal 
            //with the help of both, we move to the left or to the right 
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);


            //works with low, middle and high element (usually starts in case when low == middle) 
            Merge(arr, lo, mid, hi);
        }


        public static void Merge(T[] arr, int low, int mid, int hi)
        {
            if (IsLess(arr[mid], arr[mid + 1]))
            {
                return;
            }

            //the current elements are added as separate data to our temporary array.
            for (int index = low; index < hi + 1; index++)
            {
                aux[index] = arr[index];
            }

            //left index start
            int leftCurrentIndex = low;
            //right index start
            int rightCurrentIndex = mid + 1;

            for (int k = low; k <= hi; k++)
            {

                //if the left are over first, this means the mid is left only next
                //also if the left are over, this means that the mid is always below every element of the right and must be counted!
                if (leftCurrentIndex > mid)
                {
                    //if left are finished, add the next right
                    arr[k] = aux[rightCurrentIndex++];
                }

                //if the right are over , this means it should get the rest of the left elements
                //also if the right are over, this means all of the left once are below the MID!
                else if (rightCurrentIndex > hi)
                {
                    //if right are finished, add the next left
                    arr[k] = aux[leftCurrentIndex++];
                }
                
                //compares the left element sequence with the right
                //whoever is less, is first , if we want ot sort it backwards , we`ll change the signs in the below two methods

                //if left is less, add left
                else if (IsLess(aux[leftCurrentIndex], aux[rightCurrentIndex]))
                {
                    arr[k] = aux[leftCurrentIndex++];
                }

                //if right is less, then add right 
                else
                {
                    arr[k] = aux[rightCurrentIndex++];
                }

            }

        }


        private static bool IsLess(T left, T right)
        {
            int compare = left.CompareTo(right);

            return compare < 0;
        }

    }
}


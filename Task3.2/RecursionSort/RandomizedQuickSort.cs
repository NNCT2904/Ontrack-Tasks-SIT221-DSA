using System;
using System.Collections.Generic;
using RecursionSort;

namespace Task3._2
{
    public class RandomizedQuickSort: ISorter
    {
        public RandomizedQuickSort() 
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            RQS<K>(sequence, comparer, 0, sequence.Length - 1);
        }

        public void RQS<K>(K[] sequence, IComparer<K> comparer, int a, int b) where K : IComparable<K>
        {
            if (a >= b) return;

            int left = a;
            int right = b-1;

            K pivot = sequence[b];
            K temp;

            
            while (left <= right)
            {
                //Scan until reaching value >= pivot
                while (left <= right && comparer.Compare(sequence[left], pivot) < 0)
                    left++;

                //Scan until reaching the value <= pivot
                while (left <= right && comparer.Compare(sequence[right], pivot) > 0)
                    right--;

                if (left <= right)
                {
                    //swap
                    temp = sequence[left];
                    sequence[left] = sequence[right];
                    sequence[right] = temp;
                    left++;
                    right--;
                }
            }

            //Put pivot to it's final place (left index)

            temp = sequence[left];
            sequence[left] = sequence[b];
            sequence[b] = temp;
            RQS(sequence, comparer, a, left - 1);
            RQS(sequence, comparer, left + 1, b);
        }

    }
}

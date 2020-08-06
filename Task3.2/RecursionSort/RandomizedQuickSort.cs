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
        
        public void RQS<K>(K[] sequence, IComparer<K> comparer, int left, int right) where K : IComparable<K>
        {
            if (left < right)
            {
                int q = RandomizedPartition(sequence, comparer, left, right);
                RQS(sequence, comparer, left, q - 1);
                RQS(sequence, comparer, q + 1, right);
            }
        }

        //Calculate random and swap with the last element
        private int RandomizedPartition<K>(K[] sequence, IComparer<K> comparer, int left, int right) where K : IComparable<K>
        {
            Random random = new Random();
            int i = random.Next( left, right);
            
            K pivot = sequence[i];
            sequence[i] = sequence[right];
            sequence[right] = pivot;

            return Partition(sequence, comparer, left, right);
        }

        //Partitioning
        private int Partition<K>(K[] sequence, IComparer<K> comparer, int left, int right) where K : IComparable<K>
        {
            K pivot = sequence[right];
            K temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (comparer.Compare( sequence[j], pivot)<=0)
                {
                    temp = sequence[j];
                    sequence[j] = sequence[i];
                    sequence[i] = temp;
                    i++;
                }
            }

            sequence[right] = sequence[i];
            sequence[i] = pivot;

            return i;
        }

    }

    //Extra quicksort without random pivot
    public class QuickSort : ISorter
    {
        public QuickSort()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            QS<K>(sequence, comparer, 0, sequence.Length - 1);
        }

        public void QS<K>(K[] sequence, IComparer<K> comparer, int a, int b) where K : IComparable<K>
        {
            if (a >= b)
                return;

            int left = a;
            int right = b - 1;

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
            QS(sequence, comparer, a, left - 1);
            QS(sequence, comparer, left + 1, b);
        }

    }

}

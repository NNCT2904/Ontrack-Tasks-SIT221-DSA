using System;
using System.Collections.Generic;
using Vector;

namespace Sorter
{
    public class BubbleSort : ISorter
    {
        public BubbleSort()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            BSort(sequence, comparer);
        }

        private void BSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            bool sorted;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                //Assume the array is sorted
                sorted = true;

                //Bubble sort, also check if the array is sorted or not
                for (int j = 0; j < sequence.Length - i - 1; j++)
                {
                    if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        K temp = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = temp;
                        sorted = false;
                    }
                }

                //If the array is already sorted then break.
                if (sorted == true)
                    break;

                //Best case is linear O(n) when the array is sorted!
            }
        }

        private void OldBSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            for (int i = sequence.Length; i >= 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (comparer.Compare(sequence[j], sequence[j + 1]) > 0)
                    {
                        K temp = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = temp;
                    }
                }
            }
            //Will run O(n^2) in every case
        }
    }
}

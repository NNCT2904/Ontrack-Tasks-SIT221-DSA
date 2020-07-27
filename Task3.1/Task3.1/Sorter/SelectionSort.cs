using System;
using System.Collections.Generic;
using Vector;

namespace Sorter
{
    public class SelectionSort : ISorter
    {
        public SelectionSort()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            for (int i = 0; i < sequence.Length; i++)
            {
                K minElement = sequence[i];
                int minLocation = i;

                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if (comparer.Compare(sequence[j], minElement) < 0)
                    {
                        minElement = sequence[j];
                        minLocation = j;
                    }
                }

                if (minLocation != i)
                {
                    K temp = sequence[minLocation];
                    sequence[minLocation] = sequence[i];
                    sequence[i] = temp;
                }
            }
        }
    }
}

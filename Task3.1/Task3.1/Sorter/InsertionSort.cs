using System;
using System.Collections.Generic;
using Vector;

namespace Sorter
{
    public class InsertionSort : ISorter
    {
        public InsertionSort()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            for (int i =0; i<sequence.Length; i++)
            {
                int j = i;
                while ((j>0) && (comparer.Compare(sequence[j-1], sequence[j])>0))
                {
                    K temp = sequence[j];
                    sequence[j] = sequence[j - 1];
                    sequence[j - 1] = temp;
                    j -= 1;
                }
            }
        }
    }
}

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
            for (int i = sequence.Length; i >= 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (comparer.Compare(sequence[j], sequence[j+1]) > 0)
                    {
                        K temp = sequence[j];
                        sequence[j] = sequence[j + 1];
                        sequence[j + 1] = temp;
                    }
                }

            }
        }

    }
}

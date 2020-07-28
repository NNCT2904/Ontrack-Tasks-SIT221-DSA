using System;
using System.Collections.Generic;
using RecursionSort;

namespace Task3._2
{
    public class MergeSortBottomUp : ISorter
    {
        public MergeSortBottomUp()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            MergeSort<K>(sequence, comparer);
        }

        private void Merge<K>(K[] sIn, K[] sOut, IComparer<K> comparer, int start, int inc) where K : IComparable<K>
        {
            int end1 = Math.Min(start + inc, sIn.Length);
            int end2 = Math.Min(start + 2 * inc, sIn.Length);
            int x = start;
            int y = start + inc;
            int z = start;

            while (x<end1 && y< end2)
            {
                if (comparer.Compare(sIn[x], sIn[y]) < 0)
                    sOut[z++] = sIn[x++];
                else
                    sOut[z++] = sIn[y++];

            }
            if (x < end1)
                Array.Copy(sIn, x, sOut, z, end1 - x);
            else if (y < end2)
                Array.Copy(sIn, y, sOut, z, end2 - y);
        }

        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            K[] src = sequence;
            K[] dest = new K[n];
            K[] temp;

            for (int i = 1; i< n; i*=2)
            {
                for (int j = 0; j< n; j+=2*i)
                {
                    Merge(src, dest, comparer, j, i);
                }
                temp = src;
                src = dest;
                dest = temp;
            }
            if (sequence != src)
            {
                Array.Copy(src, 0, sequence, 0, n);
            }
        }

        
    }
}

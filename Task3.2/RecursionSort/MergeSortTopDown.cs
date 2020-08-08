using System;
using System.Linq;
using System.Collections.Generic;
using RecursionSort;

namespace Task3._2
{
    public class MergeSortTopDown : ISorter
    {
        public MergeSortTopDown()
        {
        }

        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            if (comparer == null)
                comparer = Comparer<K>.Default;

            MergeSort<K>(sequence, comparer);
        }
        //Merge S1 and S2 to S
        private void Merge<K>(K[] s1, K[] s2, K[] s, IComparer<K> comparer) where K : IComparable<K>
        {
            int i = 0, j = 0;
            while (i + j < s.Length)
            {
                if (j == s2.Length || (i < s1.Length && comparer.Compare(s1[i], s2[j]) < 0))
                    s[i + j] = s1[i++];
                else
                    s[i + j] = s2[j++];
            }
        }

        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int n = sequence.Length;
            //when array length is 1, it is sorted
            if (n < 2) return;

            //chop chop
            int mid = n / 2;
            K[] s1 = sequence.Take(mid).ToArray();
            K[] s2 = sequence.Skip(mid).ToArray();

            //conquer, sort the 2 sequences recursively
            MergeSort(s1, comparer);
            MergeSort(s2, comparer);

            //Merge result to original
            Merge(s1, s2, sequence, comparer);
        }
    }
}

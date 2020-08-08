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
        private void MergeSort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            int currentSize = sequence.Length;
            //Original array
            K[] src = sequence;
            //New Temporary array
            K[] dest = new K[currentSize];
            //Just for swapping stuff
            K[] temp; 

            for (int i = 1; i< currentSize; i*=2)
            {
                for (int j = 0; j< currentSize; j+=2*i)
                {
                    Merge(src, dest, comparer, j, i);
                }
                
                /*
                Copy elements back and forth between 2 buffer
                for the next iteration
                */
                temp = src;
                src = dest;
                dest = temp;
            }
            if (sequence != src)
            {
                Array.Copy(src, 0, sequence, 0, currentSize);
            }
        }

        //s1 is left sequence
        //s2 is right sequence
        //merge s1, s2 from 
        private void Merge<K>(K[] s1, K[] s2, IComparer<K> comparer, int start, int inc) where K : IComparable<K>
        {
            //End points for run 1 and 2
            int end1 = Math.Min(start + inc, s1.Length);
            int end2 = Math.Min(start + 2 * inc, s1.Length);

            //Index for run 1
            int x = start;
            //Index for run 2
            int y = start + inc;
            //Index for output
            int z = start;

            while (x<end1 && y< end2)
            {
                if (comparer.Compare(s1[x], s1[y]) < 0)
                    s2[z++] = s1[x++];
                else
                    s2[z++] = s1[y++];

            }
            if (x < end1)
                Array.Copy(s1, x, s2, z, end1 - x);
            else if (y < end2)
                Array.Copy(s1, y, s2, z, end2 - y);
        }

        

        
    }
}

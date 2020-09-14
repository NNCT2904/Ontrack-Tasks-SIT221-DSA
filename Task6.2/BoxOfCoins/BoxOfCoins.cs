using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {

        public static int Solve(int[] boxes)
        {
            int sum = Sum(boxes);

            int alexValue = AlexMaxCoins(boxes);
            int cindyValue = sum - alexValue;

            return alexValue - cindyValue;
        }

        private static int Sum(int[] boxes)
        {
            int sum = 0;
            foreach (int item in boxes)
            {
                sum += item;
            }
            return sum;
        }

        // The recursion way, wayyyyyyy more expensive, it will check the result in every single way
        private static int AlexMaxCoins(int[] boxes, int start, int end)
        {
            if (start > end) return 0;

            int a = boxes[start] + Math.Min(AlexMaxCoins(boxes, start + 2, end), AlexMaxCoins(boxes, start + 1, end - 1));
            int b = boxes[end] + Math.Min(AlexMaxCoins(boxes, start + 1, end - 1), AlexMaxCoins(boxes, start, end - 2));

            return Math.Max(a, b);
        }

        private static int AlexMaxCoins(int[] boxes)
        {
            // Time and complexity: O(n^2)
            // 
            int n = boxes.Length;
            int[,] table = new int[n, n];

            int x, y, z;
            for (int a = 0; a < n; ++a)
            {
                for (int i = 0, j = a; j < n; ++i, ++j)
                {
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i<= (j-2))?table[i,j-2]:0;
                    table[i,j] = Math.Max(boxes[i] + Math.Min(x, y), boxes[j] + Math.Min(y,z));
                }
            }
            return table[0, n-1];
        }
    }

}
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {
        List<string> m = new List<string>();
        public static int Solve(int[] boxes)
        {
            int sum = Sum(boxes);

            int alexValue = AlexMaxCoins(boxes, 0, boxes.Length-1);
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

        // The recursion way, wayyyyyyy more expensive, 
        // it will check the result in every single way
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
            int n = boxes.Length;
            int[,] table = new int[n, n];

            int x, y, z;
            for (int a = 0; a < n; ++a)
            {
                for (int i = 0, j = a; j < n; ++i, ++j)
                {
                    x = ((i + 2) <= j) ? table[i + 2, j] : 0;
                    y = ((i + 1) <= (j - 1)) ? table[i + 1, j - 1] : 0;
                    z = (i <= (j - 2)) ? table[i, j - 2] : 0;
                    table[i, j] = Math.Max(boxes[i] + Math.Min(x, y), boxes[j] + Math.Min(y, z));
                }
            }
            PrintTable(table);
            return table[0, n - 1];
        }
        /* 
        The original array:

        int[] boxes 
           |x x x x x x|
            0 1 2 3 4 5
            i-->

        Fill the table like this (upper triangular matrix):
        int[,] table
            j-->
            0 1 2 3 4 5
            ___________
        i 0|x x x x x x
        | 1|0 x x x x x
        v 2|0 0 x x x x
          3|0 0 0 x x x
          4|0 0 0 0 x x
          5|0 0 0 0 0 x

        table[i,j] is the maximum value that users can get, from ith to jth index
        ex: table[1,3]
            j-->
            0 1 2 3 4 5
            ___________
        i 0|x x x x x x
        | 1|0 x x(*)x x
        v 2|0 0 x x x x
          3|0 0 0 x x x
          4|0 0 0 0 x x
          5|0 0 0 0 0 x

        The marked position is represent of the maximum value can get from 2 indexes:
           |x x x x x x|
            0 1 2 3 4 5
              i   j
        
        for each choices from user, the opponent 
        */

        private static void PrintTable(int[,] table)
        {
            int n = table.GetLength(0) - 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,7}", table[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

}
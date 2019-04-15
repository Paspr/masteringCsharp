using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            int min = 0;
            int max = a.Length - 1;
            int[] BSTarray = new int[a.Length];
            BuildArray(a, min, max);

            int BuildArray (int[] num, int minInput, int maxInput)
            {
                int middle = (minInput + maxInput) / 2;
                num[0] = a[middle];
                if (minInput > maxInput)
                {
                    return 0;
                }
                else
                {
                    return (BuildArray(num, minInput, middle - 1));
                    BuildArray(num, middle + 1, maxInput);
                }
                //return 0;
            }


            return BSTarray;
        }
    }
}
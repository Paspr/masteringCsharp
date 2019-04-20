using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            int[] BSTarray = new int[a.Length];
            int index = 0;

            void BST (int[] array, int minInput, int maxInput, int level, int treshold = 0)
            {
                if (minInput > maxInput)
                {
                    return;
                }
                int middle = minInput+((maxInput - minInput) / 2);
                
                if (treshold == level)
                {
                    if (index>= array.Length || middle >= array.Length)
                    {
                        return;
                    }
                    else
                    {
                        array[index] = a[middle];
                        index++;
                        return;
                    }  
                }
           
                BST(array, minInput, middle, level, treshold + 1);
                BST(array, middle+1, maxInput, level, treshold + 1);
            }
            for (int i=0; i < (int)Math.Log(a.Length, 2) + 1; i++)
            {
                BST(BSTarray, 0, a.Length, i);
            }
            return BSTarray;
        }

    }
}
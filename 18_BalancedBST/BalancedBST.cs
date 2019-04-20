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

            for (int i = 0; i < (int)Math.Log(a.Length, 2) + 1; i++)
            {
                BalancedBST.BST.BSTGenerate(a, BSTarray, 0, a.Length, i);
            }
            return BSTarray;
        }
            

        public class BST
        {
            public static int index=0;
            public static void BSTGenerate(int[] source, int[] array, int minInput, int maxInput, int level, int treshold = 0)
            {
               
                if (minInput > maxInput)
                {
                    return;
                }
                int middle = minInput + ((maxInput - minInput) / 2);

                if (treshold == level)
                {
                    if (BalancedBST.BST.index >= array.Length || middle >= array.Length)
                    {
                        return;
                    }
                    else
                    {
                        array[BalancedBST.BST.index] = source[middle];
                        BalancedBST.BST.index++;
                        return;
                    }
                }
                BSTGenerate(source, array, minInput, middle, level, treshold + 1);
                BSTGenerate(source, array, middle + 1, maxInput, level, treshold + 1);
            }
        }
    }         
}

    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] completeTree = {15,2,13,4,11,6,7,10,9,8,5,12,3,14,1};
            int[] incompleteTree = { 25, 50, 75, 3, 62, 37, 84, 9, 7, 8, 10, 12, 11 };
            int[] test=BalancedBST.GenerateBBSTArray(completeTree);
            Console.WriteLine("Test for complete binary tree");
            if (test[0] == 8 && test[1] == 4 && test[2] == 12 && test[3] == 2 && test[4] == 6 && test[5] == 10 && 
                test[6] == 14 && test[7] == 1 && test[8] == 3 && test[9] == 5 && test[10] == 7 && test[11] == 9 && 
                test[12] == 11 && test[13] == 13 && test[14]==15 )
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            BalancedBST.BST.index = 0;
            int[] test2 = BalancedBST.GenerateBBSTArray(incompleteTree);
            Console.WriteLine("Test for incomplete binary tree");
            if (test2[0] == 12 && test2[1] == 9 && test2[2] == 62 && test2[3] == 7 && test2[4] == 11 && test2[5] == 37 &&
                test2[6] == 84 && test2[7] ==3 && test2[8] == 8 && test2[9] == 10 && test2[10] == 12 && test2[11] ==25 &&
                test2[12] == 50)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
    }
}

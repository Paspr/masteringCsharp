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
            int[] test = {15, 2, 13, 4, 11, 6, 7, 10, 9, 8, 5, 12, 3, 14, 1};
            BalancedBST tree = new BalancedBST();
            tree.CreateFromArray(test);
            
            Console.WriteLine("Test for tree generation");
            tree.GenerateTree();
            if (tree.Root.NodeKey == 8 && tree.Root.Level == 1 && tree.Root.LeftChild.NodeKey == 4 && tree.Root.LeftChild.Level == 2 &&
                 tree.Root.RightChild.NodeKey == 12 && tree.Root.RightChild.Level == 2 && tree.Root.LeftChild.LeftChild.NodeKey == 2 &&
                 tree.Root.LeftChild.LeftChild.Level == 3 && tree.Root.LeftChild.RightChild.NodeKey == 6 &&
                 tree.Root.LeftChild.RightChild.Level == 3 &&
                 tree.Root.RightChild.LeftChild.NodeKey == 10 && tree.Root.RightChild.LeftChild.Level == 3 &&
                 tree.Root.RightChild.RightChild.NodeKey == 14 && tree.Root.RightChild.RightChild.Level == 3 &&
                 tree.Root.LeftChild.LeftChild.LeftChild.NodeKey == 1 && tree.Root.LeftChild.LeftChild.LeftChild.Level == 4 &&
                 tree.Root.LeftChild.LeftChild.RightChild.NodeKey == 3 && tree.Root.LeftChild.LeftChild.RightChild.Level == 4 &&
                 tree.Root.LeftChild.RightChild.LeftChild.NodeKey == 5 && tree.Root.LeftChild.RightChild.LeftChild.Level == 4 &&
                 tree.Root.LeftChild.RightChild.RightChild.NodeKey == 7 && tree.Root.LeftChild.RightChild.RightChild.Level == 4 &&
                 tree.Root.RightChild.LeftChild.LeftChild.NodeKey == 9 && tree.Root.RightChild.LeftChild.LeftChild.Level == 4 &&
                 tree.Root.RightChild.LeftChild.RightChild.NodeKey == 11 && tree.Root.RightChild.LeftChild.RightChild.Level == 4 &&
                 tree.Root.RightChild.RightChild.LeftChild.NodeKey == 13 && tree.Root.RightChild.RightChild.LeftChild.Level == 4 &&
                 tree.Root.RightChild.RightChild.RightChild.NodeKey == 15 && tree.Root.RightChild.RightChild.RightChild.Level == 4)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Test for balance check of the tree");
            if (tree.IsBalanced(tree.Root)==true)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.ReadKey();
        }
    }
}

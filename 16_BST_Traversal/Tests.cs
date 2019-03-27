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
            // define test nodes
            BSTNode<int> root8 = new BSTNode<int>(8, 8, null);

            // define test tree
            BST<int> BinTree = new BST<int>(root8);
            BinTree.AddKeyValue(4, 4);
            BinTree.AddKeyValue(12, 12);
            BinTree.AddKeyValue(2, 2);
            BinTree.AddKeyValue(1, 1);
            BinTree.AddKeyValue(3, 3);
            BinTree.AddKeyValue(6, 6);
            BinTree.AddKeyValue(5, 5);
            BinTree.AddKeyValue(7, 7);
            BinTree.AddKeyValue(10, 10);
            BinTree.AddKeyValue(9, 9);
            BinTree.AddKeyValue(11, 11);
            BinTree.AddKeyValue(14, 14);
            BinTree.AddKeyValue(13, 13);
            BinTree.AddKeyValue(15, 15);
            // Breadth-first traversal test 
            Console.WriteLine("Breadth - first traversal test");
            if (BinTree.WideAllNodes().Count == 15 && BinTree.WideAllNodes()[0].NodeKey == 8 && BinTree.WideAllNodes()[1].NodeKey == 4
                && BinTree.WideAllNodes()[2].NodeKey == 12 && BinTree.WideAllNodes()[3].NodeKey == 2 && BinTree.WideAllNodes()[4].NodeKey == 6
                && BinTree.WideAllNodes()[5].NodeKey == 10 && BinTree.WideAllNodes()[6].NodeKey == 14 && BinTree.WideAllNodes()[7].NodeKey == 1
                && BinTree.WideAllNodes()[8].NodeKey == 3 && BinTree.WideAllNodes()[9].NodeKey == 5 && BinTree.WideAllNodes()[10].NodeKey == 7
                && BinTree.WideAllNodes()[11].NodeKey == 9 && BinTree.WideAllNodes()[12].NodeKey == 11 && BinTree.WideAllNodes()[13].NodeKey == 13
                && BinTree.WideAllNodes()[14].NodeKey == 15)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Depth-first traversal tests
            // 0 (in-order)
            Console.WriteLine("Depth-first in-order traversal test");
            if (BinTree.DeepAllNodes(0).Count == 15 && BinTree.DeepAllNodes(0)[0].NodeKey == 1 && BinTree.DeepAllNodes(0)[1].NodeKey == 2
                && BinTree.DeepAllNodes(0)[2].NodeKey == 3 && BinTree.DeepAllNodes(0)[3].NodeKey == 4 && BinTree.DeepAllNodes(0)[4].NodeKey == 5
                && BinTree.DeepAllNodes(0)[5].NodeKey == 6 && BinTree.DeepAllNodes(0)[6].NodeKey == 7 && BinTree.DeepAllNodes(0)[7].NodeKey == 8
                && BinTree.DeepAllNodes(0)[8].NodeKey == 9 && BinTree.DeepAllNodes(0)[9].NodeKey == 10 && BinTree.DeepAllNodes(0)[10].NodeKey == 11
                && BinTree.DeepAllNodes(0)[11].NodeKey == 12 && BinTree.DeepAllNodes(0)[12].NodeKey == 13 && BinTree.DeepAllNodes(0)[13].NodeKey == 14
                && BinTree.DeepAllNodes(0)[14].NodeKey == 15)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // 1 (post-order)
            Console.WriteLine("Depth-first post-order traversal test");
            if (BinTree.DeepAllNodes(1).Count == 15 && BinTree.DeepAllNodes(1)[0].NodeKey == 1 && BinTree.DeepAllNodes(1)[1].NodeKey == 3
                && BinTree.DeepAllNodes(1)[2].NodeKey == 2 && BinTree.DeepAllNodes(1)[3].NodeKey == 5 && BinTree.DeepAllNodes(1)[4].NodeKey == 7
                && BinTree.DeepAllNodes(1)[5].NodeKey == 6 && BinTree.DeepAllNodes(1)[6].NodeKey == 4 && BinTree.DeepAllNodes(1)[7].NodeKey == 9
                && BinTree.DeepAllNodes(1)[8].NodeKey == 11 && BinTree.DeepAllNodes(1)[9].NodeKey == 10 && BinTree.DeepAllNodes(1)[10].NodeKey == 13
                && BinTree.DeepAllNodes(1)[11].NodeKey == 15 && BinTree.DeepAllNodes(1)[12].NodeKey == 14 && BinTree.DeepAllNodes(1)[13].NodeKey == 12
                && BinTree.DeepAllNodes(1)[14].NodeKey == 8)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // 2 (pre-order)
            Console.WriteLine("Depth-first pre-order traversal test");
            if (BinTree.DeepAllNodes(2).Count == 15 && BinTree.DeepAllNodes(2)[0].NodeKey == 8 && BinTree.DeepAllNodes(2)[1].NodeKey == 4
                && BinTree.DeepAllNodes(2)[2].NodeKey == 2 && BinTree.DeepAllNodes(2)[3].NodeKey == 1 && BinTree.DeepAllNodes(2)[4].NodeKey == 3
                && BinTree.DeepAllNodes(2)[5].NodeKey == 6 && BinTree.DeepAllNodes(2)[6].NodeKey == 5 && BinTree.DeepAllNodes(2)[7].NodeKey == 7
                && BinTree.DeepAllNodes(2)[8].NodeKey == 12 && BinTree.DeepAllNodes(2)[9].NodeKey == 10 && BinTree.DeepAllNodes(2)[10].NodeKey == 9
                && BinTree.DeepAllNodes(2)[11].NodeKey == 11 && BinTree.DeepAllNodes(2)[12].NodeKey == 14 && BinTree.DeepAllNodes(2)[13].NodeKey == 13
                && BinTree.DeepAllNodes(2)[14].NodeKey == 15)
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

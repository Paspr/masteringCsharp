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
            
            // search test
            Console.WriteLine("FindNodeByKey method test");
            Console.WriteLine("search for existing key");
            if (BinTree.FindNodeByKey(8).NodeHasKey==true && BinTree.FindNodeByKey(8).Node.NodeKey==8)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("requested key will be added as a left child");
            if (BinTree.FindNodeByKey(4).NodeHasKey == false && BinTree.FindNodeByKey(4).ToLeft == true)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("requested key will be added as a right child");
            if (BinTree.FindNodeByKey(12).NodeHasKey == false && BinTree.FindNodeByKey(12).ToLeft == false)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // adding test
            Console.WriteLine();
            Console.WriteLine("AddKeyValue method test");
            Console.WriteLine("adding node as a left child");
            if (BinTree.FindNodeByKey(4).NodeHasKey == false && BinTree.AddKeyValue(4, 4))
            {
                if (BinTree.FindNodeByKey(4).NodeHasKey == true) Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("adding node as a right child");
            if (BinTree.FindNodeByKey(12).NodeHasKey == false && BinTree.AddKeyValue(12, 12))
            {
                if (BinTree.FindNodeByKey(12).NodeHasKey == true) Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("adding existing node");
            if (BinTree.AddKeyValue(12, 12)==false)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // find max and min key test
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
            Console.WriteLine();
            Console.WriteLine("FinMinMax method test");
            Console.WriteLine("Search max key value starting from the root");
            if (BinTree.FinMinMax(BinTree.Root, true).NodeKey==15)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search max key value starting from the subtree");
            if (BinTree.FinMinMax(BinTree.Root.LeftChild, true).NodeKey == 7)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search min key value starting from the root");
            if (BinTree.FinMinMax(BinTree.Root, false).NodeKey == 1)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search min key value starting from the subtree");
            if (BinTree.FinMinMax(BinTree.Root.RightChild, false).NodeKey == 9)
            {
                Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // delete node test
            Console.WriteLine();
            Console.WriteLine("DeleteNodeByKey method test");
            if (BinTree.FindNodeByKey(5).NodeHasKey == true)
            {
                if (BinTree.DeleteNodeByKey(5) && BinTree.Root.LeftChild.RightChild.LeftChild==null) Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }
            if (BinTree.FindNodeByKey(4).NodeHasKey == true)
            {
                if (BinTree.DeleteNodeByKey(4) && BinTree.FindNodeByKey(4).NodeHasKey == false && BinTree.Root.LeftChild.NodeKey==7) Console.WriteLine("OK");

            }
            else
            {
                Console.WriteLine("FAIL");
            }

            BinTree.DeleteNodeByKey(12); 
            BinTree.DeleteNodeByKey(13);
            Console.ReadKey();
        }
    }
}

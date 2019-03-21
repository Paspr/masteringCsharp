using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2
{
    class Program
    {
        
        static void PrintWithLevel(SimpleTree<int> Tree)
        {
            Queue<SimpleTreeNode<int>> numbers = new Queue<SimpleTreeNode<int>>();
            Queue<SimpleTreeNode<int>> neighbors = new Queue<SimpleTreeNode<int>>();
            if (Tree.Root.Children != null)
            {
                numbers.Enqueue(Tree.Root);
                int level = 0;

                while (numbers.Count != 0 || neighbors.Count != 0)
                {
                    Console.WriteLine("Node level: {0}", level);
                    while (numbers.Count != 0)
                    {
                        SimpleTreeNode<int> tempNode = numbers.Dequeue();
                        Console.WriteLine(tempNode.NodeValue);
                        if (tempNode.Children != null && tempNode.Children.Count > 0)
                        {

                            for (int i = 0; i < tempNode.Children.Count; i++)
                                neighbors.Enqueue(tempNode.Children[i]);
                        }
                    }
                    Console.WriteLine();
                    level++;
                    Console.WriteLine("Node level: {0}", level);
                    while (neighbors.Count != 0)
                    {
                        SimpleTreeNode<int> tempNode2 = neighbors.Dequeue();
                        Console.WriteLine(tempNode2.NodeValue);
                        if (tempNode2.Children != null && tempNode2.Children.Count > 0)
                        {

                            for (int i = 0; i < tempNode2.Children.Count; i++)
                                numbers.Enqueue(tempNode2.Children[i]);
                        }
                    }
                    Console.WriteLine();
                    level++;
                }
            }
            else
            {
                Console.WriteLine("Tree is empty");
            }
        }

        static void Main(string[] args)
        {
           
            // define test nodes
            SimpleTreeNode<int> root9 = new SimpleTreeNode<int>(9, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, root9);
            SimpleTreeNode<int> node17 = new SimpleTreeNode<int>(17, root9);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, node4);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, node4);
            SimpleTreeNode<int> node22 = new SimpleTreeNode<int>(22, node17);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, node6);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, node6);
            SimpleTreeNode<int> node20 = new SimpleTreeNode<int>(20, node22);
            SimpleTreeNode<int> node99 = new SimpleTreeNode<int>(99, node7);
            // define test tree
            SimpleTree<int> Tree = new SimpleTree<int>(root9);
            Tree.AddChild(root9, node4);
            Console.WriteLine("AddChild method test, adding a new node");
            Tree.AddChild(root9, node17);
            if (root9.Children[1].NodeValue==17 && root9.Children[1].Parent==root9)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Tree.AddChild(node4, node3);
            Tree.AddChild(node4, node6);
            Tree.AddChild(node17, node22);
            Tree.AddChild(node22, node20);
            Tree.AddChild(node6, node5);
            Tree.AddChild(node6, node7);
            Tree.AddChild(node7, node99);

            Console.WriteLine("DeleteNode method test, deleting a new node");
            Tree.DeleteNode(node99);
            if (node7.Children.Count == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }

            Console.WriteLine("GetAllNodes method test, getting all nodes");
            List<SimpleTreeNode<int>> returnedNodes = new List<SimpleTreeNode<int>>();
            returnedNodes=Tree.GetAllNodes();
            if (returnedNodes.Count == 9 && returnedNodes[0].NodeValue==9 && returnedNodes[1].NodeValue == 4
                && returnedNodes[2].NodeValue == 17 && returnedNodes[3].NodeValue == 3 && returnedNodes[4].NodeValue == 6
                && returnedNodes[5].NodeValue == 22 && returnedNodes[6].NodeValue == 5 && returnedNodes[7].NodeValue == 7
                && returnedNodes[8].NodeValue == 20)
                
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }

            Console.WriteLine("FindNodesByValue method test, finding a node by value");
            List<SimpleTreeNode<int>> returnedNode = new List<SimpleTreeNode<int>>();
            returnedNode=Tree.FindNodesByValue(6);
            if (returnedNode.Count == 1 && returnedNode[0].NodeValue == 6)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("MoveNode method test, moving a node with its subtree");
            Tree.MoveNode(node6, root9);
            if (Tree.Root.Children[0].Children.Count == 1 && Tree.Root.Children.Count == 3
                && Tree.Root.Children[2].Children.Count == 2 && Tree.Root.Children[2].NodeValue == 6)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Count nodes method test, counting nodes");
            if (Tree.Count() == 9)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("LeafCount method test, counting leaves");
            if (Tree.LeafCount() == 4)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine();
            Console.WriteLine("Printing tree by levels");
            PrintWithLevel(Tree);
            Console.ReadKey();

        }
    }
}

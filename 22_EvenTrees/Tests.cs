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
            SimpleTreeNode<int> root1 = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, root1);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, root1);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, node3);
            
            // define test tree
            SimpleTree<int> Tree = new SimpleTree<int>(root1);

            Tree.AddChild(root1, node2);
            Tree.AddChild(root1, node3);
            Tree.AddChild(node3, node4);
            
            Console.WriteLine("Tree1 test");
            List<int> treeResult = Tree.EvenTrees();
            if (treeResult.Count==2 && treeResult[0]==1 && treeResult[1] == 3)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
   
            
            SimpleTreeNode<int> root2 = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node11 = new SimpleTreeNode<int>(2, root2);
            SimpleTreeNode<int> node12 = new SimpleTreeNode<int>(3, root2);
            SimpleTreeNode<int> node13 = new SimpleTreeNode<int>(6, root2);

            SimpleTreeNode<int> node21 = new SimpleTreeNode<int>(5, node11);
            SimpleTreeNode<int> node22 = new SimpleTreeNode<int>(7, node11);
            SimpleTreeNode<int> node23 = new SimpleTreeNode<int>(4, node12);
            SimpleTreeNode<int> node24 = new SimpleTreeNode<int>(8, node13);

            SimpleTreeNode<int> node31 = new SimpleTreeNode<int>(9, node22);
            SimpleTreeNode<int> node32 = new SimpleTreeNode<int>(10, node22);

            SimpleTree<int> Tree2 = new SimpleTree<int>(root2);
            Tree2.AddChild(root2, node11);
            Tree2.AddChild(root2, node12);
            Tree2.AddChild(root2, node13);

            Tree2.AddChild(node11, node21);
            Tree2.AddChild(node11, node22);
            Tree2.AddChild(node12, node23);
            Tree2.AddChild(node13, node24);

            Tree2.AddChild(node24, node31);
            Tree2.AddChild(node24, node32);

            Console.WriteLine("Tree2 test");
            List<int> tree2Result = Tree2.EvenTrees();
            if (tree2Result.Count == 4 && (tree2Result[0] == 1 && tree2Result[1] == 3 ||
                tree2Result[0] == 1 && tree2Result[1] == 6) &&
                (tree2Result[2] == 1 && tree2Result[3] == 3 ||
                tree2Result[2] == 1 && tree2Result[3] == 6))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            /*
            SimpleTreeNode<int> root3 = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node11 = new SimpleTreeNode<int>(2, root3);
            SimpleTreeNode<int> node12 = new SimpleTreeNode<int>(3, root3);
            SimpleTreeNode<int> node13 = new SimpleTreeNode<int>(4, root3);
            SimpleTreeNode<int> node14 = new SimpleTreeNode<int>(5, root3);
            SimpleTreeNode<int> node15 = new SimpleTreeNode<int>(6, root3);

            SimpleTreeNode<int> node21 = new SimpleTreeNode<int>(7, node11);
            SimpleTreeNode<int> node22 = new SimpleTreeNode<int>(8, node11);
            SimpleTreeNode<int> node23 = new SimpleTreeNode<int>(9, node13);
            SimpleTreeNode<int> node24 = new SimpleTreeNode<int>(10, node13);
            SimpleTreeNode<int> node25 = new SimpleTreeNode<int>(11, node14);
            SimpleTreeNode<int> node26 = new SimpleTreeNode<int>(12, node14);
            SimpleTreeNode<int> node27 = new SimpleTreeNode<int>(13, node15);
            SimpleTreeNode<int> node28 = new SimpleTreeNode<int>(14, node15);

            SimpleTreeNode<int> node31 = new SimpleTreeNode<int>(15, node24);
            SimpleTreeNode<int> node32 = new SimpleTreeNode<int>(16, node26);
            SimpleTreeNode<int> node33 = new SimpleTreeNode<int>(17, node28);
            SimpleTreeNode<int> node34 = new SimpleTreeNode<int>(18, node28);

            SimpleTreeNode<int> node41 = new SimpleTreeNode<int>(19, node31);
            SimpleTreeNode<int> node42 = new SimpleTreeNode<int>(20, node31);
            SimpleTree<int> Tree3 = new SimpleTree<int>(root3);
            Tree3.AddChild(root3, node11);
            Tree3.AddChild(root3, node12);
            Tree3.AddChild(root3, node13);
            Tree3.AddChild(root3, node14);
            Tree3.AddChild(root3, node15);

            Tree3.AddChild(node11, node21);
            Tree3.AddChild(node11, node22);
            Tree3.AddChild(node13, node23);
            Tree3.AddChild(node13, node24);
            Tree3.AddChild(node14, node25);
            Tree3.AddChild(node14, node26);
            Tree3.AddChild(node15, node27);
            Tree3.AddChild(node15, node28);

            Tree3.AddChild(node24, node31);
            Tree3.AddChild(node26, node32);
            Tree3.AddChild(node28, node33);
            Tree3.AddChild(node28, node34);

            Tree3.AddChild(node31, node41);
            Tree3.AddChild(node31, node42);

            Tree3.EvenTrees();
            */
            Console.ReadKey();
        }
    }
}

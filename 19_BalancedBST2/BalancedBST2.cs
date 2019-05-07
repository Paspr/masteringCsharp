using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root;

        public int[] BSTArray; // временный массив для ключей дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void CreateFromArray(int[] a)
        {
            // создаём массив дерева BSTArray из заданного
            Array.Sort(a);
            int[] BSTArray2 = new int[a.Length];
            for (int i = 0; i < (int)Math.Log(a.Length, 2) + 1; i++)
            {
                BST.BSTGenerate(a, BSTArray2, 0, a.Length, i);
            }
            BSTArray = new int[a.Length];
            for (int i = 0; i < BSTArray2.Length; i++)
            {
                BSTArray[i] = BSTArray2[i];
            }
        }

        public void GenerateTree()
        {

            // создаём дерево с нуля из массива BSTArray
            // ...
            if (BSTArray!=null)
            {
                Root = new BSTNode(BSTArray[0], null);
                Root.Level = 1;
            }
            Queue<BSTNode> nodes = new Queue<BSTNode>();
            nodes.Enqueue(Root);
            int i = 0;
            while (nodes.Count != 0)
            {
                BSTNode tempNode = nodes.Dequeue();
                //(2 * i + 1) >= BSTArray.Length
                if ((2 * i + 1) >= BSTArray.Length) break; //(2 * i + 1)< BSTArray.Length-1 || tempNode.LeftChild == null
                else
                {
                    tempNode.LeftChild = new BSTNode(BSTArray[2 * i + 1], tempNode);
                    if (tempNode.LeftChild.NodeKey >= tempNode.NodeKey) break;
                    tempNode.LeftChild.Level = tempNode.LeftChild.Parent.Level + 1;
                    nodes.Enqueue(tempNode.LeftChild);
                }
                if ((2 * i + 2) >= BSTArray.Length) break;
                else
                {
                
                    tempNode.RightChild= new BSTNode(BSTArray[2 * i + 2], tempNode);
                    if (tempNode.RightChild.NodeKey < tempNode.NodeKey) break;
                    tempNode.RightChild.Level = tempNode.RightChild.Parent.Level + 1;
                    nodes.Enqueue(tempNode.RightChild);
                }
                i++;
            }
        }

        public bool IsBalanced(BSTNode root_node)
        {
            // сбалансировано ли дерево с корнем root_node

            if (root_node == null)
            {
                return true;
            }

            int leftHeight = GetHeight(root_node.LeftChild);
            int rightHeight = GetHeight(root_node.RightChild);
            if (Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int GetHeight(BSTNode root_node)
        {
            if (root_node == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(root_node.LeftChild), GetHeight(root_node.RightChild));
        }

    }
    public class BST
    {
        public static int index = 0;
        public static void BSTGenerate(int[] source, int[] array, int minInput, int maxInput, int level, int treshold = 0)
        {

            if (minInput > maxInput)
            {
                return;
            }
            int middle = minInput + ((maxInput - minInput) / 2);

            if (treshold == level)
            {
                if (BST.index >= array.Length || middle >= array.Length)
                {
                    return;
                }
                else
                {
                    array[BST.index] = source[middle];
                    BST.index++;
                    return;
                }
            }
            BSTGenerate(source, array, minInput, middle, level, treshold + 1);
            BSTGenerate(source, array, middle + 1, maxInput, level, treshold + 1);
        }
    }
}
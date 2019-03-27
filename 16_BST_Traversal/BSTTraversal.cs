using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если не найден узел, и в дереве только один корень
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        public BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> result = new BSTFind<T>();
            // ищем в дереве узел и сопутствующую информацию по ключу
            Queue<BSTNode<T>> nodes = new Queue<BSTNode<T>>();
            if (Root != null)
            {
                nodes.Enqueue(Root);
                while (nodes.Count != 0)
                {
                    BSTNode<T> tempNode = nodes.Dequeue();
                    if (tempNode.NodeKey == key)
                    {

                        result.NodeHasKey = true;
                        result.Node = tempNode;
                        return result;
                    }
                    else if (tempNode.NodeKey < key)
                    {
                        if (tempNode.RightChild == null)
                        {
                            result.NodeHasKey = false;
                            result.Node = tempNode;
                            result.ToLeft = false;
                            return result;
                        }
                        else
                        {
                            if (tempNode.RightChild.NodeKey == key)
                            {

                                result.NodeHasKey = true;
                                result.Node = tempNode.RightChild;
                                return result;
                            }
                            else
                            {
                                nodes.Enqueue(tempNode.RightChild);
                            }
                        }
                    }
                    else if (tempNode.NodeKey > key)
                    {
                        if (tempNode.LeftChild == null)
                        {
                            result.NodeHasKey = false;
                            result.Node = tempNode;
                            result.ToLeft = true;
                            return result;
                        }
                        else
                        {
                            if (tempNode.LeftChild.NodeKey == key)
                            {

                                result.NodeHasKey = true;
                                result.Node = tempNode.LeftChild;
                                return result;
                            }
                            else
                            {
                                nodes.Enqueue(tempNode.LeftChild);
                            }
                        }
                    }
                }
            }
            return null;
        }


        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            BSTFind<T> result = new BSTFind<T>();
            result = FindNodeByKey(key);
            if (result == null || result.NodeHasKey == true)
            {
                return false; // если ключ уже есть
            }
            else
            {
                if (result.ToLeft == true)
                {
                    BSTNode<T> parentNode = result.Node;
                    BSTNode<T> addedNode = new BSTNode<T>(key, val, parentNode);
                    parentNode.LeftChild = addedNode;
                    return true;
                }
                if (result.ToLeft == false)
                {
                    BSTNode<T> parentNode = result.Node;
                    BSTNode<T> addedNode = new BSTNode<T>(key, val, parentNode);
                    parentNode.RightChild = addedNode;
                    return true;
                }
            }
            return true;
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            //Breadth - first traversal
            Queue<BSTNode<T>> nodes = new Queue<BSTNode<T>>();
            List<BSTNode<T>> result = new List<BSTNode<T>>();
            if (Root != null)
            {
                nodes.Enqueue(Root);
                while (nodes.Count != 0)
                {
                    BSTNode<T> tempNode = nodes.Dequeue();
                    result.Add(tempNode);
                    if (tempNode.LeftChild != null)
                    {
                        nodes.Enqueue(tempNode.LeftChild);
                    }
                    if (tempNode.RightChild != null)
                    {
                        nodes.Enqueue(tempNode.RightChild);
                    }
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public List<BSTNode<T>> DeepAllNodes(int traversalType) //  0 (in-order), 1 (post-order) и 2 (pre-order)
        {
            if (traversalType == 0) // 0 (in-order)
            {
                if (Root!=null)
                { 
                    Stack<BSTNode<T>> nodes = new Stack<BSTNode<T>>();
                    List<BSTNode<T>> getnodes = new List<BSTNode<T>>();
                    BSTNode<T> current = Root;
                    while (current != null || nodes.Count != 0)
                    {

                        while (current != null)
                        {
                            nodes.Push(current);
                            current = current.LeftChild;
                        }
                        current = nodes.Pop();
                        getnodes.Add(current);
                        current = current.RightChild;
                    }
                    return getnodes;
                }
                else
                {
                    return null;
                }
            }
            else if (traversalType==1) // 1 (post-order)
            {
                if (Root != null)
                {
                    Stack<BSTNode<T>> nodes = new Stack<BSTNode<T>>();
                    Stack<BSTNode<T>> nodesPostOrder = new Stack<BSTNode<T>>();
                    List<BSTNode<T>> getnodes = new List<BSTNode<T>>();
                    BSTNode<T> current = Root;
                    nodes.Push(current);
                    while (nodes.Count != 0)
                    {
                        current = nodes.Pop();
                        nodesPostOrder.Push(current);
                        if (current.LeftChild!=null) nodes.Push(current.LeftChild);
                        if (current.RightChild != null) nodes.Push(current.RightChild);
                        getnodes.Add(nodesPostOrder.Peek());
                    }
                    getnodes.Reverse();
                    return getnodes;
                }
                else
                {
                    return null;
                }
            }
            else if (traversalType==2) // 2 (pre-order)
            {
                if (Root != null)
                {
                    Stack<BSTNode<T>> nodes = new Stack<BSTNode<T>>();
                    List<BSTNode<T>> getnodes = new List<BSTNode<T>>();
                    BSTNode<T> current = Root;
                    nodes.Push(current);
                    while (nodes.Count!=0)
                    {
                        current = nodes.Pop();
                        getnodes.Add(current);
                        if (current.RightChild != null) nodes.Push(current.RightChild);
                        if (current.LeftChild != null) nodes.Push(current.LeftChild);
                    }
                    return getnodes;
                }
                else
                {
                    return null;
                }
            } 
            return null;
        }

    }
}

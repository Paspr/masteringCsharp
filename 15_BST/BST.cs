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
            if (result == null || result.NodeHasKey==true)
            {
                return false; // если ключ уже есть
            }
            else
            {
                if (result.ToLeft==true)
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

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            Queue<BSTNode<T>> nodes = new Queue<BSTNode<T>>();
            if (FromNode != null)
            {
                nodes.Enqueue(FromNode);
                while (nodes.Count != 0)
                {
                    BSTNode<T> tempNode = nodes.Dequeue();
                    if (FindMax==true)
                    {
                        if (tempNode.RightChild == null) return tempNode;
                        else
                        {
                            nodes.Enqueue(tempNode.RightChild);
                        }
                    }
                    if (FindMax == false)
                    {
                        if (tempNode.LeftChild == null) return tempNode;
                        else
                        {
                            nodes.Enqueue(tempNode.LeftChild);
                        }
                    }
                }
                return nodes.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            BSTFind<T> result = new BSTFind<T>();
            result = FindNodeByKey(key);
            if (result.NodeHasKey == false) return false; // если узел не найден
            else
            {
                if (result.Node.LeftChild == null && result.Node.RightChild == null)
                {
                    if (result.Node.Parent.LeftChild.NodeKey == key) result.Node.Parent.LeftChild = null;
                    if (result.Node.Parent.RightChild.NodeKey == key) result.Node.Parent.RightChild = null;
                }
                if (result.Node.LeftChild == null && result.Node.RightChild != null)
                {
                    if (result.Node.Parent.RightChild.NodeKey == key)
                    {
                        BSTNode<T> tempNode = result.Node.RightChild;
                        result.Node.Parent.RightChild.NodeKey = tempNode.NodeKey;
                        result.Node.Parent.RightChild.NodeValue = tempNode.NodeValue;
                        result.Node.Parent.RightChild.RightChild = null;
                    }
                }
                if (result.Node.LeftChild != null && result.Node.RightChild == null)
                {
                    if (result.Node.Parent.LeftChild.NodeKey == key)
                    {
                        BSTNode<T> tempNode = result.Node.LeftChild;
                        result.Node.NodeKey = tempNode.NodeKey; // result.Node.Parent.LeftChild.NodeKey = tempNode.NodeKey;
                        result.Node.NodeValue = tempNode.NodeValue; // result.Node.Parent.LeftChild.NodeValue = tempNode.NodeValue;
                        result.Node.RightChild = null; //result.Node.Parent.LeftChild.LeftChild
                    }
                }
                if (result.Node.LeftChild != null && result.Node.RightChild != null)
                {
                    Queue<BSTNode<T>> nodes = new Queue<BSTNode<T>>();
                    nodes.Enqueue(result.Node.RightChild);
                    while (nodes.Count != 0)
                    {
                        BSTNode<T> tempNode = nodes.Dequeue();
                        if (tempNode.LeftChild == null && tempNode.RightChild == null)
                        {
                            result.Node.NodeKey = tempNode.NodeKey; // result.Node.Parent.LeftChild.NodeValue = tempNode.NodeValue
                            result.Node.NodeValue = tempNode.NodeValue; // result.Node.Parent.LeftChild.NodeKey = tempNode.NodeKey
                            tempNode.Parent.LeftChild = null; // result.Node.Parent.LeftChild.RightChild.LeftChild
                            break;
                        }
                        if (tempNode.LeftChild == null && tempNode.RightChild != null)
                        {
                            result.Node.NodeKey = tempNode.RightChild.NodeKey;
                            result.Node.NodeValue = tempNode.RightChild.NodeValue;
                            result.Node.RightChild.RightChild = null;
                            break;
                        }
                        else
                        {
                            nodes.Enqueue(tempNode.LeftChild);
                        }
                    }
                }
                return true;
            }
        }

    }
}
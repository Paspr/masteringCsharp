using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            if (ParentNode.Children == null)
            {
                List<SimpleTreeNode<T>> Children = new List<SimpleTreeNode<T>>();
                ParentNode.Children = Children;
                ParentNode.Children.Add(NewChild);
                NewChild.Parent = ParentNode;
            }
            else
            {
                if (!ParentNode.Children.Contains(NewChild) && ParentNode != NewChild)
                {
                    ParentNode.Children.Add(NewChild);
                    NewChild.Parent = ParentNode;
                }
            }
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            // ваш код удаления существующего узла NodeToDelete
            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            //if (NodeToDelete.Parent.Children.Count == 0) NodeToDelete.Parent.Children[0] == null;
            NodeToDelete.Parent = null;
            
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            List<SimpleTreeNode<T>> nodes = new List<SimpleTreeNode<T>>();
            Queue<SimpleTreeNode<T>> numbers = new Queue<SimpleTreeNode<T>>();
            if (Root.Children != null)
            {
                numbers.Enqueue(Root);
                while (numbers.Count != 0)
                {
                    SimpleTreeNode<T> tempNode = numbers.Dequeue();
                   
                        nodes.Add(tempNode);
        
                    if (tempNode.Children != null && tempNode.Children.Count > 0)
                    {
                        for (int i = 0; i < tempNode.Children.Count; i++)
                            numbers.Enqueue(tempNode.Children[i]);
                    }
                }
            }
            return nodes;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            List<SimpleTreeNode<T>> nodes = new List<SimpleTreeNode<T>>();
            Queue<SimpleTreeNode<T>> numbers = new Queue<SimpleTreeNode<T>>();
            if (Root.Children != null)
            {
                numbers.Enqueue(Root);
                while (numbers.Count != 0)
                {
                    SimpleTreeNode<T> tempNode = numbers.Dequeue();
                    if (Equals(tempNode.NodeValue, val))
                    {
                        nodes.Add(tempNode);
                    }
                    if (tempNode.Children!=null && tempNode.Children.Count>0)
                    {
                        for (int i = 0; i< tempNode.Children.Count; i++)
                        numbers.Enqueue(tempNode.Children[i]);
                    }
                }
            }
            return nodes;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent
            if (OriginalNode.Children==null || OriginalNode.Children.Count==0)
            {
                SimpleTreeNode<T> tempNode = OriginalNode;
                DeleteNode(OriginalNode);
                AddChild(NewParent, tempNode);
            }
            else
            {
                SimpleTreeNode<T> tempNode = OriginalNode;
                DeleteNode(OriginalNode);
                AddChild(NewParent, tempNode);
                for (int i = 0; i < tempNode.Children.Count; i++)
                {
                    SimpleTreeNode<T> tempNode2 = tempNode.Children[i];
                    AddChild(tempNode, tempNode2);
                }
            }
        }
        

        public int Count()
        {
            // количество всех узлов в дереве
            int nodesNubmer = 0;
            Queue<SimpleTreeNode<T>> numbers = new Queue<SimpleTreeNode<T>>();
            if (Root.Children != null)
            {
                numbers.Enqueue(Root);

                while (numbers.Count != 0)
                {
                    SimpleTreeNode<T> tempNode = numbers.Dequeue();
                    nodesNubmer++;
                    if (tempNode.Children != null && tempNode.Children.Count > 0)
                    {
                        for (int i = 0; i < tempNode.Children.Count; i++)
                            numbers.Enqueue(tempNode.Children[i]);
                    }
                }
            }
            else
            {
                if (Root != null) nodesNubmer++;
            }
            return nodesNubmer;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            int leavesNubmer = 0;
            Queue<SimpleTreeNode<T>> numbers = new Queue<SimpleTreeNode<T>>();
            if (Root.Children != null)
            {
                numbers.Enqueue(Root);
                while (numbers.Count != 0)
                {
                    SimpleTreeNode<T> tempNode = numbers.Dequeue();

                    if (tempNode.Children == null || tempNode.Children.Count == 0) leavesNubmer++;

                    if (tempNode.Children != null && tempNode.Children.Count > 0)
                    {
                        for (int i = 0; i < tempNode.Children.Count; i++)
                            numbers.Enqueue(tempNode.Children[i]);
                    }
                }
            }
            else
            {
                if (Root != null) leavesNubmer++;
            }
            return leavesNubmer;
        }

    }

}
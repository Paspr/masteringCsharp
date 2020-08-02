using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        // add a new node at the end of linked list
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        // find the node by the specified value
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        // find all nodes by the specified value
        // return the list of found nodes
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        // remove node by the specified value
        {
            if (Find(_value) == null) return false;                 // if the specified is not in the list
            if (head == null) return false;                         // if the list is empty
            else
            {
                Node CurrentNode = head;
                Node PreviousNode = null;
                while (CurrentNode != null)
                {
                    if (CurrentNode.value == _value)
                    {

                        if (head.next == null)                              // if the removing node is the only element in the list
                        {
                            head = null;
                            tail = null;
                            return true;                                    // if node was removed
                        }

                        if (head.value == CurrentNode.value)        // if node is in the beginning of the list
                        {

                            head = head.next;
                            return true; // if node was removed
                        }
                        else
                        {
                            if (CurrentNode.next == null)           // if node was the last element in the list
                            {
                                PreviousNode.next = null;
                                tail = PreviousNode;
                                return true; // if node was removed
                            }
                            else                                    // node is in the beginning of the list
                            {
                                PreviousNode.next = CurrentNode.next;
                                return true; // if node was removed
                            }
                        }
                    }
                    PreviousNode = CurrentNode;
                    CurrentNode = CurrentNode.next;
                }
                return true; // if node was removed
            }
        }

        public void RemoveAll(int _value)
        // // remove all nodes by the specified value
        {
            int length = Count();
            for (int i = 0; i < length; i++)
            {
                Remove(_value);
            }
        }

        public void Clear()
        // clear the list
        {
            head = null;
            tail = null;
        }

        public int Count()
        // count nodes in the list
        {
            if (head == null) return 0;
            else
            {
                Node node = head;
                int i = 0;
                while (node != null)
                {
                    i = i + 1;
                    node = node.next;
                }
                return i;
            }
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        // insert node after the specified one
        {
            Node CurrentNode = head;
            if ((_nodeAfter == null) & (head == null))   // if _nodeAfter = null and the list is empty
            {                                           // add a new node in the beginning of the list
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                tail = head;
            }
            while (CurrentNode != null)
            {
                if (CurrentNode.value == _nodeAfter.value)
                {
                    _nodeAfter.next = CurrentNode.next;
                    _nodeToInsert.next = _nodeAfter.next;
                    CurrentNode.next = _nodeToInsert;
                    if (tail.next != null) tail = CurrentNode.next;
                }
                CurrentNode = CurrentNode.next;
            }
        }
    }
}
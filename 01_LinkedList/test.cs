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
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
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
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            foreach (Node element in nodes)                   // печать элементов списка для проверки работы метода
            {
                Console.WriteLine(element);
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (Find(_value) == null) return false;                 // если значения нет в списке
            if (head == null) return false;                         // если список пуст
            else
            {
                    Node CurrentNode = head;
                    Node PreviousNode = null;
                    while (CurrentNode != null)
                    {
                        if (CurrentNode.value == _value)
                        {

                        if (head.next == null)                              // если удаляется элемент из списка с одним элементом
                        {
                            head = null;
                            tail = null;
                            return true;                                    // если узел был удален
                        }

                        if (head.value == CurrentNode.value)        // если элемент находится в начале списка
                            {
                            
                            head = head.next;
                                return true; // если узел был удален
                            }
                            else
                            {
                            if (CurrentNode.next == null)           // если элемент находится последним в списке
                            {
                                PreviousNode.next = null;
                                tail = PreviousNode;
                                return true; // если узел был удален
                            }
                            else                                    // элемент находится в середине списка
                            {
                                PreviousNode.next = CurrentNode.next;
                                return true; // если узел был удален
                            }
                        }
                        }
                        PreviousNode = CurrentNode;
                        CurrentNode = CurrentNode.next;
                    }
                    return true; // если узел был удален
            }
        }

        public void RemoveAll(int _value) // удаления всех узлов по заданному значению
        {
            int length = Count();
            for (int i=0; i < length; i++)
            { 
                Remove(_value);
            }
        }

        public void Clear() // очистка всего списка
        {
            head = null;
            tail = null;
        }

        public int Count() // подсчет количества элементов в списке
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

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert) // вставка узла после заданного
        {
            Node CurrentNode = head;
            if ((_nodeAfter==null) & (head==null))      // если _nodeAfter = null и список пустой, 
            {                                           // добавить новый элемент первым в списке 
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
                   if (tail.next!=null) tail = CurrentNode.next;
                }
                CurrentNode = CurrentNode.next;
            }
        }
    }
}
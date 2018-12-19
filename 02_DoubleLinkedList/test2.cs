using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
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

        public List<Node> FindAll(int _value)           // здесь будет ваш код поиска всех узлов по заданному значению
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

        public bool Remove(int _value)                                      // здесь будет ваш код удаления одного узла по заданному значению
        {

            if (Find(_value) == null) return false;                         // если значения нет в списке
            if (head == null) return false;                                 // если список пуст
            else
            {
                Node CurrentNode = head;
                while (CurrentNode != null)
                {
                    if (CurrentNode.value == _value)
                    {

                        if (head.next == null)                              // если удаляется элемент из списка с одним элементом
                        {
                            head = null;
                            tail = null;
                            return true;                                    // если узел был удалён
                        }

                        if (head.value == CurrentNode.value)                // если элемент находится в начале списка
                        {
                            head = head.next;
                            head.prev = null;
                            return true;                                    // если узел был удалён
                        }
                        else 
                        {
                            if (CurrentNode.next == null)                   // если элемент находится последним в списке
                            { 
                                CurrentNode.prev.next = null;
                                tail = CurrentNode.prev;
                                return true;                                // если узел был удалён
                            }
                            else                                            // элемент находится в середине списка
                            { 
                                CurrentNode.prev.next = CurrentNode.next;
                                CurrentNode.next.prev = CurrentNode.prev;
                                return true;                                // если узел был удалён
                            }
                        }
                    }
                    CurrentNode = CurrentNode.next;
                }
                return true;                                                // если узел был удалён
            }
        }

        public void RemoveAll(int _value)                                   // здесь будет ваш код удаления всех узлов по заданному значению
        {
            int length = Count();
            for (int i = 0; i < length; i++)
            {
                Remove(_value);
            }
        }

        public void Clear()                                                // здесь будет ваш код очистки всего списка
        {
            head = null;
            tail = null;
        }

        public int Count()                                                 // здесь будет ваш код подсчёта количества элементов в списке
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

        public void insertInHead(Node _nodeToInsert)                     // здесь будет ваш код вставки узла первым
        {
            Node CurrentNode = head;
            if (head == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
                tail = head;
            }
            else
            {
                head = _nodeToInsert;
                CurrentNode.prev= head;
                head.next= CurrentNode;
            }
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)    // здесь будет ваш код вставки узла после заданного узла
        {
            Node CurrentNode = head;
            if ((_nodeAfter == null) & (head == null)) insertInHead(_nodeToInsert);      // если _nodeAfter = null и список пустой, 
                                                                                        // добавьте новый элемент первым в списке 
            else
            {
                if ((_nodeAfter == null) & (head != null)) AddInTail(_nodeToInsert);         // если _nodeAfter = null и список непустой,
                else                                                                         // добавьте новый элемент последним в списке 
                {
                    while (CurrentNode != null)
                    {
                        if (CurrentNode.value == _nodeAfter.value)
                        {
                            _nodeAfter.next = CurrentNode.next;
                            _nodeToInsert.next = _nodeAfter.next;
                            _nodeToInsert.prev = CurrentNode;
                            CurrentNode.next = _nodeToInsert;
                            if (tail.next != null) tail = CurrentNode.next;
                            if (_nodeAfter.next==null) _nodeAfter.next.next.prev = _nodeToInsert;
                            if (_nodeToInsert.next != null) _nodeToInsert.next.prev = _nodeToInsert;
                        }
                        CurrentNode = CurrentNode.next;
                    }
                }
            }
        }
    }
}
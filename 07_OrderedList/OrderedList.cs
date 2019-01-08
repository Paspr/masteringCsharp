using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // linguistic string comparison
                string v1temp = v1.ToString();
                string v2temp = v2.ToString();
                result=String.Compare(v1temp.Trim(), v2temp.Trim());
                
            }
            else
            {
                // other types
                // -1 if v1 < v2
                // 0 if v1 == v2
                // +1 if v1 > v2
                int v1temp = Convert.ToInt32(v1);
                int v2temp = Convert.ToInt32(v2);
                if (v1temp == v2temp)
                {
                    result = 0;
                }
                else
                {
                    result = (v1temp < v2temp) ? -1 : 1;
                }
            }

            return result;

        }

        public void Add(T value)
        {
            // insert value 
            // at corresponding position
            Node<T> temp = new Node<T>(value);
            if (head == null)
            {
                temp.next = head;
                head = temp;
                tail = head;
            }
            else
            {
                if (_ascending) { 
                Node<T> CurrentNode = head;
                while (CurrentNode != null && (Compare(CurrentNode.value, temp.value) == -1))
                {
                    CurrentNode = CurrentNode.next;
                }
                if (CurrentNode == head)
                {
                    CurrentNode.prev = temp;
                    CurrentNode.prev.next = head;
                    head = CurrentNode.prev;
                }
                else
                {
                    if (CurrentNode != null)
                    {
                        CurrentNode.prev.next = temp;
                        CurrentNode.prev.next.next = CurrentNode;
                        CurrentNode.prev.next.prev = CurrentNode.prev;
                        CurrentNode.prev = CurrentNode.prev.next;
                    }
                    else
                    {
                        tail.next = temp;
                        tail.next.prev = tail;
                        tail = tail.next;
                    }
                }
            }
                else
                {
                    Node<T> CurrentNode = head;
                    while (CurrentNode != null && (Compare(CurrentNode.value, temp.value) == 1))
                    {
                        CurrentNode = CurrentNode.next;
                    }
                    if (CurrentNode == head)
                    {
                        CurrentNode.prev = temp;
                        CurrentNode.prev.next = head;
                        head = CurrentNode.prev;
                    }
                    else
                    {
                        if (CurrentNode != null)
                        {
                            CurrentNode.prev.next = temp;
                            CurrentNode.prev.next.next = CurrentNode;
                            CurrentNode.prev.next.prev = CurrentNode.prev;
                            CurrentNode.prev = CurrentNode.prev.next;
                        }
                        else
                        {
                            tail.next = temp;
                            tail.next.prev = tail;
                            tail = tail.next;
                        }
                    }
                }
            }
        }

        public Node<T> Find(T val)
        {
            
            Node<T> node = head;
            if (_ascending)
            {
                while (node != null && (Compare(node.value, val) == -1 || Compare(node.value, val) == 0))
                {
                    if (Compare(node.value, val) == 0) return node;
                    node = node.next;
                }
                return null;
            }
            
            
            else 
            {
                while (node != null && (Compare(node.value, val) == 1 || Compare(node.value, val) == 0))
                {
                    if (Compare(node.value, val) == 0) return node;
                    node = node.next;
                }
                return null;
            }  
        }

        public void Delete(T val)
        {
            if (Find(val) == null) return;                            // there is no such element at the list
            if (head == null) return;                                 // the list is empty
            else
            {
                Node<T> CurrentNode = head;
                while (CurrentNode != null)
                {
                    if (Compare(CurrentNode.value, val)==0)
                    {

                        if (head.next == null)                              // if there is the only element at the list
                        {
                            head = null;
                            tail = null;
                            return;                                    // element was deleted
                        }

                        if (Compare(head.value, CurrentNode.value)==0)                // element at the beginning of the list
                        {
                            head = head.next;
                            head.prev = null;
                            return;                                    
                        }
                        else
                        {
                            if (CurrentNode.next == null)                   // element at the end of the list
                            {
                                CurrentNode.prev.next = null;
                                tail = CurrentNode.prev;
                                return;                                
                            }
                            else                                            // element at the middle of the list
                            {
                                CurrentNode.prev.next = CurrentNode.next;
                                CurrentNode.next.prev = CurrentNode.prev;
                                return;                                
                            }
                        }
                    }
                    CurrentNode = CurrentNode.next;
                }
                return;                                                
            }
        }

        public void Clear(bool asc)
        {
            // clear the list
            _ascending = asc;
            head = null;
            tail = null;
            
        }

        public int Count()
        {
            // count elements
            if (head == null) return 0;
            else
            {
                Node<T> node = head;
                int i = 0;
                while (node != null)
                {
                    i = i + 1;
                    node = node.next;
                }
                return i;
            }
           
        }

        List<Node<T>> GetAll() // receive all elements of the ordered list 
                               // as a standart list
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }

    }

}
 
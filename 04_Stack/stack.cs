using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        readonly LinkedList<T> list = new LinkedList<T>();


        public int Size()
        {
            // размер текущего стека
            if (list.Count != 0) return list.Count;
            else
            {
                return 0;
            }
        }

        public T Pop()
        {
            
            if (list.Count != 0)
            {
                T firstElement = list.First.Value;
                list.RemoveFirst();
                return firstElement;  
                
            }
            else
            {
                return default(T); // null, если стек пустой
            }
        }

        public void Push(T val)
        {
            
            list.AddFirst(val); // было AddLast
        }

        public T Peek()
        {
            
            if (list.Count != 0)
            {
                return list.First.Value; 
            }
            else
            {
                return default(T); // null, если стек пустой
            }       
        }
    }
}
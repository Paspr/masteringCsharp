using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        readonly LinkedList<T> list = new LinkedList<T>();
        public Stack()
        {
            // инициализация внутреннего хранилища стека
        }

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
            // ваш код
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
            // ваш код
            list.AddFirst(val); // было AddLast, ошибка Некорректная операция push() или peek() для непустого стека
        }

        public T Peek()
        {
            // ваш код
            if (list.Count != 0)
            {
                return list.Last.Value; // было list.First.Value, ошибка Некорректная операция push() или peek() для непустого стека
            }
            else
            {
                return default(T); // null, если стек пустой
            }       
        }
    }
}
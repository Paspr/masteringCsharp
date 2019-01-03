using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        readonly LinkedList<T> list = new LinkedList<T>();
        public Queue()
        {
            // инициализация внутреннего хранилища очереди
        }

        public void Enqueue(T item)
        {
            // вставка в хвост
            list.AddFirst(item);
        }

        public T Dequeue()
        {
            // выдача из головы
            if (list.Count != 0)
            {
                T LastElement = list.Last.Value;
                list.RemoveLast();
                return LastElement;

            }
            else
            {
                return default(T); // если очередь пустая
            }
        }

        public int Size()
        {
            if (list.Count != 0) return list.Count;
            else
            {
                return 0;
            }
        }
    }
}
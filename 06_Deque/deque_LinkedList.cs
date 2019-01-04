using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        readonly LinkedList<T> list = new LinkedList<T>();
        public Deque()
        {
            // инициализация внутреннего хранилища
        }

        public void AddFront(T item)
        {

            // добавление в голову
            list.AddFirst(item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            list.AddLast(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (list.Count != 0)
            {
                T firstElement = list.First.Value;
                list.RemoveFirst();
                return firstElement;
            }
            else
            {
                return default(T);
            }
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            if (list.Count != 0)
            {
                T lastElement = list.Last.Value;
                list.RemoveLast();
                return lastElement;
            }
            else
            {
                return default(T);
            }
        }

        public int Size()
        {
            // размер очереди
            if (list.Count != 0) return list.Count;
            else
            {
                return 0;
            }
        }
    }

}
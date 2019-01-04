using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        readonly List<T> list = new List<T>();
        public Deque()
        {
            // инициализация внутреннего хранилища
        }

        public void AddFront(T item)
        {

            // добавление в голову
            list.Insert(0, item);
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            list.Add(item);
        }

        public T RemoveFront()
        {
            // удаление из головы
            if (list.Count != 0)
            {
                T firstElement = list[0];
                list.RemoveAt(0);
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
                T lastElement = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
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
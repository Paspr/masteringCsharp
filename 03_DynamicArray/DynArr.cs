using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)                 // ваш код
        {
            if (count==0)
            {
                array = new T[new_capacity];
                capacity = new_capacity;
            }
            else
            {
                T[] temp= new T[new_capacity];
                Array.Copy(array, 0, temp, 0, capacity);
                array = temp;
                //array = new T[new_capacity];
                //Array.Copy(temp, 0, array, 0, new_capacity);
                capacity = new_capacity;
            } 
        }

        public T GetItem(int index)                             // ваш код
        {
            if ((index >= capacity) || (index<0))  throw new IndexOutOfRangeException("Индекс вне допустимых границ");
            else 
            {
                return array[index];
            }
            //return default(T);
        }

        public void Append(T itm)                               // ваш код
        {
            array[capacity-1] = itm;
            //array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index == capacity) Append(itm);
            if ((index > capacity) || (index < 0)) throw new IndexOutOfRangeException("Индекс вне допустимых границ");
            else
            {
                Array.Copy(array, index, array, index + 1, count);
                array[index] = itm;
                count++;
            }
        }

        public void Remove(int index)                                // ваш код
        {
            if (index == capacity - 1) array[index] = default(T);
            for (int j = index; j < capacity - 1; j++)
            {
                array[j] = array[j + 1];
            }
            count--;
        }

    }
}
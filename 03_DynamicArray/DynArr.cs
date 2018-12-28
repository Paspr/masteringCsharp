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
                Array.Copy(array, 0, temp, 0, count);
                array = temp;
                capacity = new_capacity;
            } 
        }

        public T GetItem(int index)                             // ваш код
        {
            if ((index >= count) || (index<0))  throw new IndexOutOfRangeException("Индекс вне допустимых границ");
            else 
            {
                return array[index];
            }
            //return default(T);
        }

        public void Append(T itm)                               // ваш код
        {
            if (count+1 > capacity)
            { 
                MakeArray(capacity * 2);
                array[count] = itm;
                count++;
            }
            else
            { 
                array[count] = itm;
                count++;
            }
        }

        public void Insert(T itm, int index)
        {
            if (index == count)
            {
                Append(itm);
                return;
            }
            if ((index > count) || (index < 0)) throw new IndexOutOfRangeException("Индекс вне допустимых границ");
            else
            {
                if (count + 1 > capacity)
                {
                    MakeArray(capacity * 2);
                    Array.Copy(array, index, array, index + 1, count - index);
                    array[index] = itm;
                    count++;
                }
                else
                {
                    Array.Copy(array, index, array, index + 1, count - index);
                    array[index] = itm;
                    count++;
                }
            }
        }

        public void Remove(int index)                                // ваш код
        {
            if ((index >= count) || (index < 0)) throw new IndexOutOfRangeException("Индекс вне допустимых границ");
            for (int j = index; j < capacity - 1; j++)
            {
                
                array[j] = array[j + 1];
            }
            count--;
            if (count < (capacity / 2))
            {
                if (count < 16)
                {
                    MakeArray(16);
                }
                else
                {
                    MakeArray((int)(capacity / 1.5));
                }
            }   
        }
    }
}
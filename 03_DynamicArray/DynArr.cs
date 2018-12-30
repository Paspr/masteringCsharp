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

        public void MakeArray(int new_capacity)         // create new array
        {
            if (count==0)                               // no elements case
            {
                array = new T[new_capacity];
                capacity = new_capacity;
            }
            else                                        // copy existing elements
            {
                T[] temp= new T[new_capacity];
                Array.Copy(array, 0, temp, 0, count);
                array = temp;
                capacity = new_capacity;
            } 
        }

        public T GetItem(int index)                     // get item by index
        {
            if ((index >= count) || (index<0))  throw new IndexOutOfRangeException("Index is out of range");
            else 
            {
                return array[index];
            }
        }

        public void Append(T itm)                      // add item in tail
        {
            if (count+1 > capacity)                    // max capacity is exceeded, array is extended
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

        public void Insert(T itm, int index)          // insert element at the specified index
        {
            if (index == count)
            {
                Append(itm);
                return;
            }
            if ((index > count) || (index < 0)) throw new IndexOutOfRangeException("Index is out of range");
            else
            {
                if (count + 1 > capacity)
                {
                    MakeArray(capacity * 2);
                    Array.Copy(array, index, array, index + 1, count - index);  // shift existing elements
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

        public void Remove(int index)               // remove element at the specified index
        {
            if ((index >= count) || (index < 0)) throw new IndexOutOfRangeException("Index is out of range");
            for (int j = index; j < capacity - 1; j++)
            {
                
                array[j] = array[j + 1];
            }
            count--;
            if (count < (capacity / 2))
            {
                if (count < 16)                    // preserve minimal array size
                {
                    MakeArray(16);
                }
                else                               // shrink array
                {
                    MakeArray((int)(capacity / 1.5));
                }
            }   
        }
    }
}
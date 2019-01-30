using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            // return slot index
            int h = 0, i = 0;
            int a = 31415, b = 27183;
            for (int j = 0; j < key.Length; j++)
            {
                h = (a * h + key[i]) % size;
                a = a * b % (size - 1);
            }
            return h;
        }

        public int SeekSlot(string value)
        {
            // search for free slot (if available)
            if (slots[HashFun(value)] == null)
            {
                int j = HashFun(value);
                return j;
            }
            else
            {
                int index = HashFun(value);
                int i = index;
                while (slots[index] != null)
                {
                    index = index + 1;
                    if (index >= size)
                    {
                        index = index - size;
                    }
                    if (slots[index] == null) return index;
                    if (slots[index] != null && index == i) break;
                }
                // there is no free slot
                return -1;
            }
        }

        public void Put(string key, T value)
        {
            // put value in the dictionary according to key value
            if (SeekSlot(key) != -1)
            {
                int j = SeekSlot(key);
                slots[j] = key;
                values[j] = value;
            }
            else
            {
                slots[FindMin(hits)] = key;
                values[FindMin(hits)] = value;
                hits[FindMin(hits)] = 0;
            }
        }

        public int FindMin (int[] hits)
        {
            int min = hits[0], minIndex = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (min > hits[i])
                {
                    min = hits[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public T Get(string key)
        {

            // search for value and return slot with it
            if (slots[HashFun(key)] != null)
            {
                int j = HashFun(key);
                if (Equals(slots[j], key))
                {
                    hits[j] = hits[j] + 1;
                    return values[j];
                }
                else
                {
                    int index = HashFun(key);
                    int i = index;
                    while (slots[index] != null)
                    {
                        index = index + 1;
                        if (index >= size)
                        {
                            index = index - size;
                        }
                        if (slots[index] == null) break;
                        else
                        {
                            if (slots[index].Equals(key))
                            {
                                hits[index] = hits[index] + 1;
                                return values[index];
                            }
                            if (slots[index] != null && index == i) break;
                        }
                    }
                }
            }
            // if slot is not found
            return default(T);
        }
    }
}
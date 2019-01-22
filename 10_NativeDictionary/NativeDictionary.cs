using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
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

        public bool IsKey(string key)
        {
            int j = HashFun(key);
            if (Equals(slots[j], key))
            {
                return true;                      // return true if key exists
            }
            else
            { 
                return false;                    // return false if key does not exist
            }
        }

        public void Put(string key, T value)
        {
            // put value in the dictionary according to key value
            int j = HashFun(key);
            slots[j] = key;
            values[j] = value;
        }

        public T Get(string key)
        {
            int j = HashFun(key);
            if (Equals(slots[j],key))
            {
                return values[j];               // return value for key
            }
            else
            { 
                return default(T);              // return null if key does not exist
            }
        }
    }
}
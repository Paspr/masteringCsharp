using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            // calclate hash and return slot
            int s = 0;
            foreach (char c in value)
            {
                s+=c;
            }
            return s%size;
        }

        public int SeekSlot(string value)
        {
            // search for free slot (if available)
            if (slots[HashFun(value)]==null)
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
                    index = index + step;
                    if (index>=size)
                    {
                         index = index-size;
                    }
                    if (slots[index] == null) return index;
                    if (slots[index] != null && index==i)  break; 
                }
            // there is no free slot
            return -1;
            }
        }

        public int Put(string value)
        {
            // put value in table
            // and return slot
            if (SeekSlot(value) != -1)
            {
                int j = SeekSlot(value);
                slots[j] = value;
                return j;
            }
            else
            {
                // it is not possible to put value into the table due to collisions
                return -1;
            } 
        }

        public int Find(string value)
        {
            // search for value and return slot with it
            if (slots[HashFun(value)] != null)
            {
                int j = HashFun(value);
                if (slots[j].Equals(value)) return j;
                else
                {
                    int index = HashFun(value);
                    int i = index;
                    while (slots[index] != null)
                    {
                        index = index + step;
                        if (index >= size)
                        {
                            index = index - size;
                        }
                        if (slots[index] == null) break;
                        else
                        { 
                            if (slots[index].Equals(value)) return index;
                            if (slots[index] != null && index == i) break;
                        }
                    }                   
                }
            }
            // if slot is not found
            return -1;
        }
    }

}
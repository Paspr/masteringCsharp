﻿using System;
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
            Random rand = new Random();
            int chooseFunction;
            chooseFunction = rand.Next(0,3); 
            switch (chooseFunction)
            {
                case 0:
                    Func<string, int> func1 = (x) =>
                    {
                        int h = 0, i = 0;
                        int a = 31415, b = 27183;
                        for (int j = 0; j < x.Length; j++)
                        {
                            h = (a * h + x[i]) % size;
                            a = a * b % (size - 1);
                        }
                        return h;
                    };
                    break;
                case 1:
                    Func<string, int> func2 = (x) =>
                    {
                        var r = new Random();                       // генерация случайного числа UInt64
                        ulong[] nums = new ulong[x.Length];
                        for (int i = 0; i < x.Length; i++)
                        {
                            var b = new byte[sizeof(ulong)];
                            r.NextBytes(b);
                            var res = BitConverter.ToUInt64(b, 0);
                            nums[i] = res;
                        }
                        ulong sum = 0;                             // вычисление хэша
                        for (int j = 0; j < x.Length; j++)
                        {
                            sum = sum + nums[j] * x[j];
                        }
                        ulong c = sum >> 32;
                        ulong k = c - (c / Convert.ToUInt64(size)) * Convert.ToUInt64(size); // замена оператора %
                        return (Convert.ToInt32(k));
                    };
                    break;
                case 2:
                    Func<string, int> func3 = (x) =>
                    {
                        var r = new Random();
                        ulong[] nums = new ulong[x.Length];
                        for (int i = 0; i < x.Length; i++)
                        {
                            var b = new byte[sizeof(ulong)];
                            r.NextBytes(b);
                            var res = BitConverter.ToUInt64(b, 0);
                            nums[i] = res;
                        }
                        ulong sum = 0;
                        for (int j = 0; j < x.Length; j += 2)
                        {
                            sum = sum + (nums[j] + x[j]) * (nums[j + 1] + x[j + 1]);
                        }
                        ulong c = sum >> 32;
                        ulong k = c - (c / Convert.ToUInt64(size)) * Convert.ToUInt64(size); // замена оператора %
                        return (Convert.ToInt32(k));
                    };
                    break;
                default:
                    break;
            }
        }

        public int HashFun(string value)
        {
            // function 1
            /*
            int h = 0, i = 0;
            int a = 31415, b = 27183;
            for (int j=0; j<value.Length; j++) { 
                h = (a * h + value[i]) % size;
                a = a * b % (size - 1);
            }
            return h;
            */

            // function 2
            /*
            var r = new Random();
            ulong[] nums = new ulong[value.Length];
            for (int i=0; i<value.Length; i++) { 
            var b = new byte[sizeof(ulong)];
            r.NextBytes(b);
            var res = BitConverter.ToUInt64(b, 0);
                nums[i] = res;
            } 
            ulong sum = 0;
            for (int j = 0; j < value.Length; j++)
            {
                sum = sum + nums[j] * value[j];
            }
            ulong c = sum >> 32;
            ulong k = c - (c / Convert.ToUInt64(size)) * Convert.ToUInt64(size); // замена оператора %
            return (Convert.ToInt32(k)); 
            */

            // function 3
            var r = new Random();
            ulong[] nums = new ulong[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                var b = new byte[sizeof(ulong)];
                r.NextBytes(b);
                var res = BitConverter.ToUInt64(b, 0);
                nums[i] = res;
            }
            ulong sum = 0;
            for (int j = 0; j < value.Length; j+=2)
            {
                sum = sum + (nums[j] + value[j]) * (nums[j + 1]  + value[j + 1]);
            }
            ulong c = sum >> 32;
            ulong k = c - (c / Convert.ToUInt64(size)) * Convert.ToUInt64(size); // замена оператора %
            return (Convert.ToInt32(k));

            /*
            // calclate hash and return slot
            int s = 0;
            foreach (char c in value)
            {
                s+=c;
            }
            return s%size;
            */
        }

        /*
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
        */
    }

}
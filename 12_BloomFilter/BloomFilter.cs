using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray barray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            barray = new BitArray(f_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            // реализация ...
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = (result * 17 + code) % 32;
            }
            return result;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = (result * 223 + code) % 32;
            }
            return result;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            barray.Set(Hash1(str1), true);
            barray.Set(Hash2(str1), true);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int i = Hash1(str1);
            int j = Hash2(str1);
            if (barray[i]==true && barray[j]==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
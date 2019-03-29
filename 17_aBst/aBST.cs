using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = (int)Math.Pow(2, depth)-1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            
            int level = (int)Math.Log(Tree.Length + 1, 2);
            // ищем в массиве индекс ключа
            if (Tree[0]!=null)
            {
                int current = 0;
                int i = 0;
                while (i < level)
                {
                    if (Tree[current] == key) return 0;
                    else if (Tree[current] < key || Tree[current] == null)
                    {
                        if (Tree[2 * current + 2] == null) return -(2 * current + 2);
                        else
                        {
                            if (Tree[2 * current + 2] == key) return 2 * current + 2;
                            else
                            {
                                current = 2 * i + 2;
                                i++;
                            }
                        }
                    }
                    else if (Tree[current] > key || Tree[current] == null)
                    {
                        if (Tree[2 * current + 1] == null) return -(2 * current + 1);
                        else
                        {
                            if (Tree[2 * current + 1] == key) return 2 * current + 1;
                            else
                            {
                                current = 2 * current + 1;
                                i++;
                            }
                        }
                    }
                }
            }
            else
            {
                return null;
            }
            return null;
            // не найден
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            if (Tree[0] == null)
            {
                Tree[0] = key;
                return 0;
            }
            if (FindKeyIndex(key)==null || FindKeyIndex(key) > 0 || (FindKeyIndex(key)==0 && Tree[0]!=null))
            {
                return -1; // индекс добавленного/существующего ключа или -1 если не удалось
            }
            else
            {
                int index = (int)FindKeyIndex(key) * (-1);
                Tree[index] = key;
                return index;
            } 
        }

    }
}
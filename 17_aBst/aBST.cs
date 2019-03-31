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
            int tree_size = (int)Math.Pow(2, depth+1)-1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {

            int level = (int)Math.Log(Tree.Length + 1, 2); // уровень дерева для обхода в цикле
            // ищем в массиве индекс ключа
            if (Tree[0]!=null)
            {
                int current = 0;
                int i = 0;
                while (i < level) // обход начинается с корня
                {
                    if (Tree[current] == key) return 0;
                    else if (Tree[current] < key || Tree[current] == null)      // переход к правому потомку
                    {
                        if (Tree[2 * current + 2] == null) return -(2 * current + 2);
                        else
                        {
                            if (Tree[2 * current + 2] == key) return 2 * current + 2;
                            else
                            {
                                current = 2 * i + 2; // переход к следующему правому потомку
                                i++;                 // переход на уровень дерева ниже
                            }
                        }
                    }
                    else if (Tree[current] > key || Tree[current] == null)      // переход к левому потомку
                    {
                        if (Tree[2 * current + 1] == null) return -(2 * current + 1);
                        else
                        {
                            if (Tree[2 * current + 1] == key) return 2 * current + 1;
                            else
                            {
                                current = 2 * current + 1; // переход к следующему левому потомку
                                i++;                       // переход на уровень дерева ниже
                            }
                        }
                    }
                }
            }
            else
            {
                return null; // не найден
            }
            return null; // не найден
        }

        public int AddKey(int key)
        {
            int? keySearchResult = FindKeyIndex(key); // результат поиска ключа
            // добавляем ключ в массив
            if (Tree[0] == null)
            {
                Tree[0] = key;
                return 0; // индекс добавленного ключа
            }
            
            else if (keySearchResult == null || keySearchResult > 0 || (keySearchResult == 0 && Tree[0]!=null))
            {
                return -1; // добавление не удалось
            }
            else
            {
                int index = (int)keySearchResult * (-1);
                Tree[index] = key;
                return index;   // индекс добавленного ключа
            } 
        }
    }
}
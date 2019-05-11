using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...
            HeapArray = new int[(int)Math.Pow(2, depth + 1) - 1];
            for (int i=0; i<a.Length; i++)
            {
                Add(a[i]);
            }
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            if (HeapArray[0]==0)
            {
                return -1; // если куча пуста
            }
            else
            {
                int max = HeapArray[0];
                HeapArray[0] = HeapArray[GetIndexNotNull(HeapArray)];
                HeapArray[GetIndexNotNull(HeapArray)] = 0;
                SiftDown(0);
                return max;
            }
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (HeapArray[0] == 0)
            {
                HeapArray[0] = key;
                return true;
            }

            int index = GetIndexNull(HeapArray);
            if (index != -1)
            {
                HeapArray[index] = key;
                SiftUp(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SiftUp(int index)
        {
            int temp;
            while (HeapArray[index] > HeapArray[(index - 1) / 2])
            {
                temp = HeapArray[(index - 1) / 2];
                HeapArray[(index - 1) / 2] = HeapArray[index];
                HeapArray[index] = temp;
                index = (index - 1) / 2;
            }
        }
    
        public void SiftDown(int index)
        {
            int temp;
            while (2 * index + 1 < GetElementsNumber(HeapArray))
            {     
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int j = left;
                if (HeapArray[right] > HeapArray[left])
                {
                    j = right;
                }
                if (HeapArray[index] >= HeapArray[j])
                {
                    break;
                }
                else
                {
                    temp = HeapArray[index];
                    HeapArray[index] = HeapArray[j];
                    HeapArray[j] = temp;
                }
                index = j;
            }
        }

        public int GetIndexNull(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) return i;
                
            }
            return -1;
        }

        public int GetElementsNumber(int[] a)
        {
            int j = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != 0) j++;

            }
            return j;
        }

        public int GetIndexNotNull(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 0) return i-1;

            }
            return a.Length-1;
        }
    }
}
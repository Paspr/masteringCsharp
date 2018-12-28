using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            DynArray<int> Arr = new DynArray<int>();
            for (int i = 0; i < 31; i++) Arr.Append(10 + i);
            Console.WriteLine("вставка, размер буфера не превышен");
            Arr.Insert(100, 1);
            if (Arr.GetItem(1) == 100 && Arr.count == 32 && Arr.capacity == 32 && Arr.GetItem(31) == 40)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("вставка, размер буфера превышен");
            Arr.Insert(200, 1);
            if (Arr.GetItem(1) == 200 && Arr.count == 33 && Arr.capacity == 64 && Arr.GetItem(32) == 40)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("удаление, размер буфера не превышен");
            Arr.Remove(30);
            if (Arr.GetItem(30) == 39 && Arr.count == 32 && Arr.capacity == 64)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("удаление, размер буфера уменьшается");
            Arr.Remove(0);
            if (Arr.GetItem(0) == 200 && Arr.count == 31 && Arr.capacity == 42)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("удаление, размер буфера уменьшается до минимального");
            for (int i = 0; i < 20; i++) Arr.Remove(0);
            if (Arr.count == 11 && Arr.capacity == 16)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("вставка в недопустимую позицию");
            Arr.Insert(200, 100);
            Console.WriteLine("удаление в недопустимой позиции");
            Arr.Remove(31);
        }
    }
}

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
            Console.WriteLine("Insert, capacity is not exceeded");
            Arr.Insert(100, 1);
            if (Arr.GetItem(1) == 100 && Arr.count == 32 && Arr.capacity == 32 && Arr.GetItem(31) == 40)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Insert, capacity is exceeded");
            Arr.Insert(200, 1);
            if (Arr.GetItem(1) == 200 && Arr.count == 33 && Arr.capacity == 64 && Arr.GetItem(32) == 40)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Remove, capacity is not exceeded");
            Arr.Remove(30);
            if (Arr.GetItem(30) == 39 && Arr.count == 32 && Arr.capacity == 64)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Remove, array shrink");
            Arr.Remove(0);
            if (Arr.GetItem(0) == 200 && Arr.count == 31 && Arr.capacity == 42)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Remove, shrink array to min size");
            for (int i = 0; i < 20; i++) Arr.Remove(0);
            if (Arr.count == 11 && Arr.capacity == 16)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Insert at invalid position");
            Arr.Insert(200, 100);
            Console.WriteLine("Remove at invalid position");
            Arr.Remove(31);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testA = new int[] {1, 2, 4, 5, 6, 8, 9, 10, 11, 16 };
            Heap test = new Heap();
            test.MakeHeap(testA, 3);
            Console.WriteLine("Making heap test");
            if (test.HeapArray[0] == 16 && test.HeapArray[1] == 11 && test.HeapArray[2] == 8 &&
                test.HeapArray[3] == 9 && test.HeapArray[4] == 10 && test.HeapArray[5] == 2 &&
                test.HeapArray[6] == 6 && test.HeapArray[7] == 1 && test.HeapArray[8] == 5 &&
                test.HeapArray[9] == 4)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Get max element from a full heap");
            if (test.GetMax()==16 && test.HeapArray[0] == 11 && test.HeapArray[1] == 10 &&
                test.HeapArray[2] == 8 && test.HeapArray[3] == 9 && test.HeapArray[4] == 4 &&
                test.HeapArray[5] == 2 && test.HeapArray[6] == 6 && test.HeapArray[7] == 1 &&
                test.HeapArray[8] == 5 && test.HeapArray[9] == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            for (int i=0; i<10; i++)
            {
                test.GetMax();
            }
            Console.WriteLine("Get max element from an empty heap");
            if (test.GetMax() == -1 && test.HeapArray[0] == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
        }
    }
}

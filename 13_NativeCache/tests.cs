using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void DisplayTable(NativeCache<object> table)
        {
            // display table and its properties to the console
            Console.WriteLine("       Table");
            Console.Write("Key");
            Console.Write("   ");
            Console.Write("Value");
            Console.Write("   ");
            Console.Write("Requests");
            Console.WriteLine();
            for (int i=0; i < table.size; i++)
            {
                
                Console.Write(table.slots[i]);
                Console.Write("   ");
                Console.Write(table.values[i]);
                Console.Write("     ");
                Console.Write(table.hits[i]);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {

            NativeCache<object> test = new NativeCache<object>(7);
            // filling in the table
            test.Put("keyA", 101);
            test.Put("keyB", 102);
            test.Put("keyC", 103);
            test.Put("keyD", 104);
            test.Put("keyE", 105);
            test.Put("keyF", 106);
            test.Put("keyG", 107);
            if (Equals(test.slots[3], "keyA") && Equals(test.values[3], 101)
                && Equals(test.slots[4], "keyB") && Equals(test.values[4], 102)
                && Equals(test.slots[5], "keyC") && Equals(test.values[5], 103)
                && Equals(test.slots[6], "keyD") && Equals(test.values[6], 104)
                && Equals(test.slots[0], "keyE") && Equals(test.values[0], 105)
                && Equals(test.slots[1], "keyF") && Equals(test.values[1], 106)
                && Equals(test.slots[2], "keyG") && Equals(test.values[2], 107))
            {
                Console.WriteLine("Filling in the table OK");
            }
            else
            {
                Console.WriteLine("Filling in the table FAIL");
            }
            // requesting stored items
            test.Get("keyA");
            test.Get("keyA");
            test.Get("keyB");
            test.Get("keyC");
            test.Get("keyC");
            test.Get("keyD");
            test.Get("keyE");
            test.Get("keyF");
            if (Equals(test.hits[3], 2) && Equals(test.hits[4], 1)
                && Equals(test.hits[5], 2) && Equals(test.hits[6], 1)
                && Equals(test.hits[0], 1) && Equals(test.hits[1], 1) && Equals(test.hits[2], 0))
            {
                Console.WriteLine("Requesting stored items OK");
            }
            else
            {
                Console.WriteLine("Requesting stored items FAIL");
            }

            DisplayTable(test);
            // putting a new element and replacing the least requested element
            test.Put("keyH", 108);
            if (Equals(test.slots[2], "keyH") && Equals(test.values[2], 108) && Equals(test.hits[2], 0))
            {
                Console.WriteLine("Putting a new element OK");
            }
            else
            {
                Console.WriteLine("Putting a new element FAIL");
            }
            // requesting a new element
            test.Get("keyH");
            test.Get("keyH");
            if (Equals(test.slots[2], "keyH") && Equals(test.values[2], 108) && Equals(test.hits[2], 2))
            {
                Console.WriteLine("Requesting a new element OK");
            }
            else
            {
                Console.WriteLine("Requesting a new element FAIL");
            }
            test.Put("keyI", 109);
            if (Equals(test.slots[0], "keyI") && Equals(test.values[0], 109) && Equals(test.hits[0], 0))
            {
                Console.WriteLine("Putting a new element OK");
            }
            else
            {
                Console.WriteLine("Putting a new element FAIL");
            }
            DisplayTable(test);
            Console.ReadKey();

        }
    }
}

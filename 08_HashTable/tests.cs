using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HashFun method test");
            HashTable test = new HashTable(17, 3);
            if (test.HashFun("abc")==5)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("SeekSlot method test, no collision");
            if (test.SeekSlot("1234") == 15)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("SeekSlot method test, a collision occurs");
            test.Put("1234");
            if (test.SeekSlot("1243") == 1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("SeekSlot method test, no free slots");
            test.Put("1243");
            test.Put("1324");
            test.Put("1342");
            test.Put("1423");
            test.Put("1432");
            test.Put("2134");
            test.Put("2143");
            test.Put("2314");
            test.Put("2341");
            test.Put("2413");
            test.Put("2431");
            test.Put("3124");
            test.Put("3142");
            test.Put("3214");
            test.Put("3241");
            test.Put("3412");
            if (test.SeekSlot("3421") == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Put method test, no collision");
            HashTable test2 = new HashTable(17, 3);
            if (test2.Put("abc") == 5)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Put method test, a collision occurs");
            if (test2.Put("cba") == 8)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Put method test, no free slots");
            if (test.Put("1234") == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Find method test, no collision");
            if (test2.Find("abc") == 5)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Find method test, a collision occurs");
            if (test2.Find("cba") == 8)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Find method test, no such value in a table with free slots");
            if (test2.Find("dbc") == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Find method test, no such value in a full table");
            if (test.Find("dbc") == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.ReadKey();
        }
    }
}

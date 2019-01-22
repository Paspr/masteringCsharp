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
            NativeDictionary<object> test = new NativeDictionary<object>(10);
            Console.WriteLine("Put method test, new key adding");
            test.Put("key", 101);
            if (Equals(test.slots[7], "key") && Equals(test.values[7], 101))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Put method test, existing key adding");
            test.Put("key", "201");
            if (Equals(test.slots[7], "key") && Equals(test.values[7], "201"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("IsKey method test, key exists");
            if (test.IsKey("key"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("IsKey method test, key does not exist");
            if (!test.IsKey("get"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Get method test, key exists");
            if (Equals(test.Get("key"),"201"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Get method test, key does not exist");
            if (Equals(test.Get("get"), null))
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

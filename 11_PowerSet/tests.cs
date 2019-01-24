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
            PowerSet<object> test = new PowerSet<object>();
            PowerSet<object> test2 = new PowerSet<object>();
            Console.WriteLine("Put method test, adding a new element");
            test.Put(123);
            if (test.Get(123)==true && test.Size()==1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Put method test, adding an existing element");
            test.Put(123);
            if (test.Get(123) == true && test.Size() == 1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Remove method test, deleting an existing element");
            test.Remove(123);
            if (test.Get(123) == false && test.Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Remove method test, deleting a nonexisting element");
            if (test.Remove(124) == false && test.Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Intersection method test, non-empty resulting set");
            test.Put(123);
            test.Put(124);
            test.Put("string");
            test2.Put(124);
            test2.Put("string");
            if (test.Intersection(test2).Size() == 2 && test.Intersection(test2).Get(124) && test.Intersection(test2).Get("string"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Intersection method test, empty resulting set");
            test2.Remove(124);
            test2.Remove("string");
            test2.Put(125);
            if (test.Intersection(test2).Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Union method test, two non-empty sets");
            if (test.Union(test2).Size() == 4 && test.Union(test2).Get(123) && test.Union(test2).Get(124) && test.Union(test2).Get(125) && test.Union(test2).Get("string"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Union method test, 1 non-empty set and 1 empty set");
            test2.Remove(125);
            if (test.Union(test2).Size() == 3 && test.Union(test2).Get(123) && test.Union(test2).Get(124) && test.Union(test2).Get("string"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Difference method test, non-empty resulting set");
            test2.Put("string");
            test2.Put(124);
            if (test.Difference(test2).Size() == 1 && test.Difference(test2).Get(123))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }

            Console.WriteLine("Difference method test, empty resulting set");
            test.Remove(123);
            if (test.Difference(test2).Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("IsSubset method test, sets are equal");
            if (test.IsSubset(test2))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("IsSubset method test, the parameter is a subset");
            test.Put(111);
            if (test.IsSubset(test2))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }

            Console.WriteLine("IsSubset method test, the parameter is not a subset");
            test2.Put(333);
            if (!test.IsSubset(test2))
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

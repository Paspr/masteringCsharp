using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Print(OrderedList<int> a)        // print the INT list
        {
            Node<int> node = a.head;
            while (node != null)
            {
                Console.Write("{0} ", node.value);
                node = node.next;
            }
            Console.WriteLine();
        }

        static void FillIn(OrderedList<int> a)      // fill in the INT list
        {
            a.Add(1805);
            a.Add(1292);
            a.Add(893);
            a.Add(271);
            a.Add(468);
            a.Add(254);
            a.Add(468);
            a.Add(1647);
            a.Add(2018);
            a.Add(1592);
            a.Add(250);
            a.Add(120);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Add method test, ascending order");
            bool ascending = true;
            OrderedList<int> list = new OrderedList<int>(ascending);
            FillIn(list);
            if (list.head.prev == null && list.head.value == 120 && list.head.next.value == 250
                && list.head.next.next.value == 254 && list.head.next.next.next.value == 271
                && list.head.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.value == 893
                && list.head.next.next.next.next.next.next.next.value == 1292
                && list.head.next.next.next.next.next.next.next.next.value == 1592
                && list.head.next.next.next.next.next.next.next.next.next.value == 1647
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 1805
                && list.head.next.next.next.next.next.next.next.next.next.next.next.value == 2018 && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Delete method test in ascending list, value to delete exists (1292)");
            list.Delete(1292);
            if (list.head.prev == null && list.head.value == 120 && list.head.next.value == 250
                && list.head.next.next.value == 254 && list.head.next.next.next.value == 271
                && list.head.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.value == 893
                && list.head.next.next.next.next.next.next.next.value == 1592
                && list.head.next.next.next.next.next.next.next.next.value == 1647
                && list.head.next.next.next.next.next.next.next.next.next.value == 1805
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 2018
                && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Delete method test in ascending list, value to delete does not exist (1234)");
            list.Delete(1234);
            if (list.head.prev == null && list.head.value == 120 && list.head.next.value == 250
                && list.head.next.next.value == 254 && list.head.next.next.next.value == 271
                && list.head.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.value == 893
                && list.head.next.next.next.next.next.next.next.value == 1592
                && list.head.next.next.next.next.next.next.next.next.value == 1647
                && list.head.next.next.next.next.next.next.next.next.next.value == 1805
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 2018
                && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Find method test in ascending list, value to find exists (1647)");
            Console.WriteLine((list.Find(1647) != null) ? "OK" : "FAIL");
            Console.WriteLine();
            Console.WriteLine("Find method test in ascending list, value to find does not exist (999)");
            Console.WriteLine((list.Find(999) == null) ? "OK" : "FAIL");
            Console.WriteLine();
            Console.WriteLine("Add method test, descending order");
            ascending = false;
            list.Clear(ascending);
            FillIn(list);
            if (list.head.prev == null && list.head.value == 2018 && list.head.next.value == 1805
                && list.head.next.next.value == 1647 && list.head.next.next.next.value == 1592
                && list.head.next.next.next.next.value == 1292
                && list.head.next.next.next.next.next.value == 893
                && list.head.next.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.next.next.value == 271
                && list.head.next.next.next.next.next.next.next.next.next.value == 254
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 250
                && list.head.next.next.next.next.next.next.next.next.next.next.next.value == 120 && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Delete method test in descending list, value to delete exists (893)");
            list.Delete(893);
            if (list.head.prev == null && list.head.value == 2018 && list.head.next.value == 1805
                && list.head.next.next.value == 1647 && list.head.next.next.next.value == 1592
                && list.head.next.next.next.next.value == 1292
                && list.head.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.next.value == 271
                && list.head.next.next.next.next.next.next.next.next.value == 254
                && list.head.next.next.next.next.next.next.next.next.next.value == 250
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 120
                && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Delete method test in descending list, value to delete does not exist (457)");
            list.Delete(457);
            if (list.head.prev == null && list.head.value == 2018 && list.head.next.value == 1805
                && list.head.next.next.value == 1647 && list.head.next.next.next.value == 1592
                && list.head.next.next.next.next.value == 1292
                && list.head.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.value == 468
                && list.head.next.next.next.next.next.next.next.value == 271
                && list.head.next.next.next.next.next.next.next.next.value == 254
                && list.head.next.next.next.next.next.next.next.next.next.value == 250
                && list.head.next.next.next.next.next.next.next.next.next.next.value == 120
                && list.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Resulting list");
            Print(list);
            Console.WriteLine();
            Console.WriteLine("Find method test in descending list, value to find exists (250)");
            Console.WriteLine((list.Find(250) != null) ? "OK" : "FAIL");
            Console.WriteLine();
            Console.WriteLine("Find method test in descending list, value to find does not exist (457)");
            Console.WriteLine((list.Find(457) == null) ? "OK": "FAIL");
        }
    }
}

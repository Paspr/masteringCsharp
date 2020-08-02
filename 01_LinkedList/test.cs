using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{

    class Program
    {
        // sum of integer values from two lists
        // if the length of the lists is equal
        // then return the list with elements
        // which are the sum of corresponding elements of the original lists
        static LinkedList ListSummer(LinkedList a, LinkedList b)
        {
            LinkedList nodes = new LinkedList();
            if (a.Count() != b.Count()) return nodes;              // if the length of the lists is different then return empty list
            else
            {
                int sum = 0;
                Node nodeA = a.head;
                Node nodeB = b.head;
                while (nodeA != null)
                {
                    sum = sum+nodeA.value + nodeB.value;           
                    nodes.AddInTail(new Node(sum));                
                    nodeA = nodeA.next;
                    nodeB = nodeB.next;
                    sum = 0;                                       // set sum to zero before new iteration
                }
                return nodes;
            }
        }

        
        static void Print (LinkedList a)
        // print list on screen
        {
            Node node = a.head;
            while (node != null)
            {
                Console.Write($"{node.value} ");
                node = node.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Test of summing two of equal lengh lists
            Console.WriteLine("Test of summing two of equal length lists");
            LinkedList one = new LinkedList();
            one.AddInTail(new Node(55));
            one.AddInTail(new Node(10));
            one.AddInTail(new Node(10));
            LinkedList two = new LinkedList();
            two.AddInTail(new Node(55));
            two.AddInTail(new Node(10));
            two.AddInTail(new Node(20));
            LinkedList ResultList = ListSummer(one, two);
            if (ResultList.head.value == 110 && ResultList.head.next.value == 20 && ResultList.tail.value == 30
                && ResultList.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of summing two of different length lists
            Console.WriteLine("Test of summing two of different length lists");
            LinkedList three = new LinkedList();
            LinkedList ResultListDIfferentLength = ListSummer(one, three);
            if (ResultListDIfferentLength.head == null && ResultListDIfferentLength.tail == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of removing one element
            Console.WriteLine("Test of removing one element");
            one.Remove(55);
            if (one.head.value == 10 && one.tail.value == 10 && one.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of removing all elements
            Console.WriteLine("Test of removing all elements");
            one.RemoveAll(10);
            if (one.head == null && one.tail == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of removing an element from the empty list
            Console.WriteLine("Test of removing an element from the empty list");
            if (one.Remove(10) == false)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of removing an element that is not in the list
            Console.WriteLine("Test of removing an element that is not in the list");
            if (two.Remove(107) == false)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of counting the nodes in the list
            Console.WriteLine("Test of counting the nodes in the list");
            if (one.Count() == 0 && two.Count() == 3)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test inserting node after the specified one
            Console.WriteLine("Test of inserting node after the specified one");
            one.InsertAfter(null, new Node(22));            // the list is empty, insertion into the beginning of the list
            Node n2 = new Node(200);
            Node n3 = new Node(100);
            Node n4 = new Node(50);
            Node n5 = new Node(5);
            one.InsertAfter(new Node(22), n2);
            one.InsertAfter(n2, n3);
            one.InsertAfter(n2, n4);
            one.InsertAfter(n3, n5);
            if (one.Count() == 5 && one.head.value == 22 && one.head.next.value == 200 && one.head.next.next.value == 50
                && one.head.next.next.next.value == 100 && one.tail.value == 5 && one.tail.next == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // Test of clearing the list
            Console.WriteLine("Test of clearing the list");
            one.Clear();
            if (one.head == null && one.tail == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            // find all nodes by the specified value
            Console.WriteLine("Test of finding all the nodes by the specified value");
            two.AddInTail(new Node(15));
            two.AddInTail(new Node(15));
            two.AddInTail(new Node(15));
            if (two.FindAll(15).Count() == 3)
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


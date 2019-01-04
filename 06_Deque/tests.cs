using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static Boolean IsPalindrome(string tocheck)
        {
            Deque<Char> symbols = new Deque<Char>();
            for (int j = 0; j < tocheck.Length; j++)
            {
                if (tocheck[j] != ' ') symbols.AddFront(tocheck[j]);
            }
            int newLength = symbols.Size();
            if (newLength % 2==0)
            { 
                while (symbols.Size()>0)
                    if (symbols.RemoveFront() != symbols.RemoveTail()) return false;
            }
            else
            {
                while (symbols.Size() > 1)
                    if (symbols.RemoveFront() != symbols.RemoveTail()) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            // int deque for testing AddFront/RemoveFront and AddTail/RemoveTail methods
            Deque<int> testDeque = new Deque<int>();
            Console.WriteLine("AddFront method test");
            testDeque.AddFront(1);
            testDeque.AddFront(2);
            testDeque.AddFront(3);
            if (testDeque.RemoveFront() == 3 && testDeque.Size() == 2)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("RemoveFront method test");
            if (testDeque.RemoveFront() == 2 && testDeque.Size() == 1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("AddTail method test");
            testDeque.AddTail(10);
            testDeque.AddTail(20);
            testDeque.AddTail(30);

            if (testDeque.RemoveTail() == 30 && testDeque.Size() == 3)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("RemoveTail method test");
            if (testDeque.RemoveTail() == 20 && testDeque.Size() == 2)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine();
            // IsPalindrome function test runs
            Console.WriteLine("Input for IsPalindrome function: мало колоколам");
            Console.Write("Result: ");
            Console.WriteLine(IsPalindrome("мало колоколам"));
            Console.WriteLine("Input for IsPalindrome function: are we not drawn onward to new era");
            Console.Write("Result: ");
            Console.WriteLine(IsPalindrome("are we not drawn onward to new era"));
            Console.WriteLine("Input for IsPalindrome function: madam");
            Console.Write("Result: ");
            Console.WriteLine(IsPalindrome("madam"));
            Console.WriteLine("Input for IsPalindrome function: just text");
            Console.Write("Result: ");
            Console.WriteLine(IsPalindrome("just text"));
            Console.ReadKey();
        }
    }
}

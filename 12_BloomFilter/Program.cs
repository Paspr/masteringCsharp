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
            BloomFilter test = new BloomFilter(32);
            Console.WriteLine("Adding 0123456789");
            test.Add("0123456789");
            Console.Write("Is 0123456789 in filter ");
            Console.WriteLine(test.IsValue("0123456789"));
            Console.Write("Is 1234567890 in filter ");
            Console.WriteLine(test.IsValue("1234567890"));
            Console.WriteLine("Adding 2345678901");
            test.Add("2345678901");
            Console.Write("Is 2345678901 in filter ");
            Console.WriteLine(test.IsValue("2345678901"));
            Console.WriteLine("Adding 3456789012");
            test.Add("3456789012");
            Console.Write("Is 3456789012 in filter ");
            Console.WriteLine(test.IsValue("3456789012"));
            Console.WriteLine("Adding 4567890123");
            test.Add("4567890123");
            Console.Write("Is 4567890123 in filter ");
            Console.WriteLine(test.IsValue("4567890123"));
            Console.WriteLine("Adding 5678901234");
            test.Add("5678901234");
            Console.Write("Is 5678901234 in filter ");
            Console.WriteLine(test.IsValue("5678901234"));
            Console.WriteLine("Adding 6789012345");
            test.Add("6789012345");
            Console.Write("Is 6789012345 in filter ");
            Console.WriteLine(test.IsValue("6789012345"));
            Console.WriteLine("Adding 7890123456");
            test.Add("7890123456");
            Console.Write("Is 7890123456 in filter ");
            Console.WriteLine(test.IsValue("7890123456"));
            Console.WriteLine("Adding 8901234567");
            test.Add("8901234567");
            Console.Write("Is 8901234567 in filter ");
            Console.WriteLine(test.IsValue("8901234567"));
            Console.WriteLine("Adding 9012345678");
            test.Add("9012345678");
            Console.Write("Is 9012345678 in filter ");
            Console.WriteLine(test.IsValue("9012345678"));
            Console.ReadKey();
        }
    }
}

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
            SimpleGraph<int> testG = new SimpleGraph<int>(5);
            testG.AddVertex(1);
            testG.AddVertex(2);
            testG.AddVertex(3);
            testG.AddVertex(4);
            testG.AddVertex(5);

            testG.AddEdge(0, 1);
            testG.AddEdge(0, 4);
            testG.AddEdge(4, 1);
            testG.AddEdge(1, 3);
            testG.AddEdge(1, 2);
            testG.AddEdge(3, 2);
            testG.AddEdge(4, 3);

            Console.WriteLine("No vertices test");
            if (testG.WeakVertices().Count == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            testG.RemoveEdge(4, 1);
            Console.WriteLine("Two vertices test");
            if (testG.WeakVertices().Count == 2)
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

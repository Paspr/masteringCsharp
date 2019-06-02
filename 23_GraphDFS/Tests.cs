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
            testG.AddEdge(0, 2);
            testG.AddEdge(1, 3);
            testG.AddEdge(2, 3);
            // tests
            Console.WriteLine("Path does not exist test");
            if (testG.DepthFirstSearch(0, 4).Count==0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            testG.AddEdge(3, 4);
            Console.WriteLine("Path exists test");
            if (testG.DepthFirstSearch(0, 4).Count == 4)
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

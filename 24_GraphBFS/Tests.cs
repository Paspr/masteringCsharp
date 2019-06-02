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
            SimpleGraph<int> testG = new SimpleGraph<int>(9);
            testG.AddVertex(1);
            testG.AddVertex(2);
            testG.AddVertex(3);
            testG.AddVertex(4);
            testG.AddVertex(5);
            testG.AddVertex(6);
            testG.AddVertex(7);
            testG.AddVertex(8);
            testG.AddVertex(9);

            testG.AddEdge(0, 1);
            testG.AddEdge(0, 5);
            testG.AddEdge(0, 7);
            testG.AddEdge(1, 2);
            testG.AddEdge(7, 2);
            testG.AddEdge(5, 6);
            testG.AddEdge(2, 8);
            testG.AddEdge(2, 3);
            testG.AddEdge(8, 6);
            testG.AddEdge(8, 4);
            testG.AddEdge(6, 4);
            testG.AddEdge(3, 4);

            Console.WriteLine("Path exists test");
            if (testG.BreadthFirstSearch(0, 6).Count == 3)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            testG.RemoveEdge(8, 4);
            testG.RemoveEdge(6, 4);
            testG.RemoveEdge(3, 4);
            Console.WriteLine("Path does not exist test");
            if (testG.BreadthFirstSearch(0, 4).Count == 0)
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

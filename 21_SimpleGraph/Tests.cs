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
            SimpleGraph testG = new SimpleGraph(5);
            // tests
            Console.WriteLine("Test adding a vertex");
            testG.AddVertex(1);
            testG.AddVertex(2);
            testG.AddVertex(3);
            testG.AddVertex(4);
            testG.AddVertex(5);
            if (testG.vertex[0].Value==1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Test adding an edge");
            testG.AddEdge(0, 4);
            testG.AddEdge(0, 1);
            testG.AddEdge(1, 0);
            testG.AddEdge(1, 2);
            testG.AddEdge(1, 3);
            testG.AddEdge(1, 4);
            testG.AddEdge(2, 1);
            testG.AddEdge(2, 3);
            testG.AddEdge(3, 1);
            testG.AddEdge(3, 2);
            testG.AddEdge(3, 4);
            testG.AddEdge(4, 0);
            testG.AddEdge(4, 1);
            testG.AddEdge(4, 3);
            if (testG.m_adjacency[0,4]==1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Test checking an edge");
            if (testG.IsEdge(0,4))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Test removing an edge");
            testG.RemoveEdge(0, 4);
            if (testG.IsEdge(0, 4)==false && testG.m_adjacency[0, 4] == 0 && testG.m_adjacency[4, 0] == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Test removing a vertex");
            testG.RemoveVertex(0);
            if (testG.vertex[0]==null && testG.m_adjacency[0, 0] == 0 && testG.m_adjacency[0, 1] == 0 &&
                testG.m_adjacency[0, 2] == 0 && testG.m_adjacency[0, 3] == 0 && testG.m_adjacency[0, 4] == 0)

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

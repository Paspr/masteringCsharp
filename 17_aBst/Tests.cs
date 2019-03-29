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
            aBST notFullTree = new aBST(4);
            notFullTree.AddKey(50);
            notFullTree.AddKey(25);
            notFullTree.AddKey(75);
            notFullTree.AddKey(37);
            notFullTree.AddKey(62);
            notFullTree.AddKey(84);
            notFullTree.AddKey(31);
            notFullTree.AddKey(43);
            notFullTree.AddKey(55);
            notFullTree.AddKey(92);
            Console.WriteLine("No full tree tests");
            Console.WriteLine("Filling test");
            if (notFullTree.Tree[0] == 50 && notFullTree.Tree[1]== 25 && notFullTree.Tree[2]== 75 && notFullTree.Tree[3]== null
                && notFullTree.Tree[4] == 37 && notFullTree.Tree[5] == 62 && notFullTree.Tree[6] == 84 && notFullTree.Tree[7] == null
                && notFullTree.Tree[8] == null && notFullTree.Tree[9] == 31 && notFullTree.Tree[10] == 43 && notFullTree.Tree[11] == 55
                && notFullTree.Tree[12] == null && notFullTree.Tree[13] == null && notFullTree.Tree[14] == 92)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search test for existing node");
            if (notFullTree.FindKeyIndex(37) == 4)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search test for 'would-be' node");
            if (notFullTree.FindKeyIndex(11) == -3)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search test for non-existing node");
            if (notFullTree.FindKeyIndex(110) == null)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Add node test for too large node");
            if (notFullTree.AddKey(110) == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Full tree tests");
            aBST fullTree = new aBST(4);
            fullTree.AddKey(8);
            fullTree.AddKey(4);
            fullTree.AddKey(12);
            fullTree.AddKey(2);
            fullTree.AddKey(6);
            fullTree.AddKey(10);
            fullTree.AddKey(14);
            fullTree.AddKey(1);
            fullTree.AddKey(3);
            fullTree.AddKey(5);
            fullTree.AddKey(7);
            fullTree.AddKey(9);
            fullTree.AddKey(11);
            fullTree.AddKey(13);
            Console.WriteLine("Add node test");
            if (fullTree.AddKey(15) == 14)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Add node in full tree test");
            if (fullTree.AddKey(1500) == -1)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Search non-existing node in the full tree test");
            if (fullTree.FindKeyIndex(50) == null)
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

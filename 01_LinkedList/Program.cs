using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class Program
    {
            /*public void PrintList()   // вывод списка на экран, работает если поместить в LinkedList в test.cs
            {
                Node node = head;
                while (node != null)
                {
                    Console.WriteLine(node.value);
                    node = node.next;
                }
            }*/

        static void Main(string[] args)
            {
            LinkedList s_list = new LinkedList();
            Node n1 = new Node(12);
            s_list.AddInTail(n1);
            s_list.Remove(12);                  // удаление одного элемента
            s_list.AddInTail(new Node(55));
            s_list.AddInTail(new Node(108));
            s_list.AddInTail(new Node(55));
            s_list.RemoveAll(55);               // удаление всех заданных элементов
            s_list.Clear();                     // очистка списка

            Console.WriteLine($"Элементов: { s_list.Count()}"); // вычисление длины списка

            Node n2 = new Node(100);
            s_list.AddInTail(n2);
            Node n3 = new Node(200);
            s_list.InsertAfter(n2, n3);             // вставка узла после заданного узла
        }
    }
}


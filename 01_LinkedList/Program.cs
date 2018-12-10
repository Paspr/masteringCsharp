using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{

    class Program
    {
        static LinkedList ListSummer(LinkedList a, LinkedList b)    // функция сложения целых значений двух списков
        {
            LinkedList nodes = new LinkedList();
            if (a.Count() != b.Count()) return nodes;              // если списки не равны — возврат пустого списка
            else
            {
                int sum = 0;
                Node nodeA = a.head;
                Node nodeB = b.head;
                while (nodeA != null)
                {
                    sum=sum+nodeA.value+ nodeB.value;              // получение суммы узлов из двух списков
                    nodes.AddInTail(new Node(sum));                // запись суммы в конец пустого списка
                    nodeA = nodeA.next;
                    nodeB = nodeB.next;
                    sum = 0;                                       // обнуление суммы перед новой итерацией цикла
                }
                return nodes;
            }
        }

        static void Print (LinkedList a)                            // функция вывода списка на экран
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
            // Тест сложения двух одинаковых списков
            LinkedList one = new LinkedList();
            one.AddInTail(new Node(55));
            one.AddInTail(new Node(10));
            one.AddInTail(new Node(10));
            LinkedList two = new LinkedList();
            two.AddInTail(new Node(55));
            two.AddInTail(new Node(10));
            two.AddInTail(new Node(20));
            Print(ListSummer(one, two));
            // Тест сложения двух неодинаковых списков
            LinkedList three = new LinkedList();
            Print(ListSummer(one, three));
            // Тест удаления одного элемента
            Console.WriteLine("Исходный список:");
            Print(one);
            one.Remove(55);
            Console.WriteLine("Список после удаления:");
            Print(one);
            // Тест удаления всех заданных элементов
            one.RemoveAll(10);
            Console.WriteLine("Список после удаления:");
            Print(one);
            // Тест удаления из пустого списка и удаления несуществующего элемента
            Console.WriteLine(one.Remove(10));
            Console.WriteLine(two.Remove(107));
            // Тест длины списка
            Console.WriteLine($"Элементов: {one.Count()}");
            Console.WriteLine($"Элементов: {two.Count()}");
            // Тест вставки узла после заданного узла
            one.InsertAfter(null, new Node(22));            // список пустой, первый узел равен null, вставка в начало списка
            Print(one);
            Node n2 = new Node(200);
            one.InsertAfter(new Node(22), n2);
            Print(one);
            // Тест очистки списка
            one.Clear();
            Print(one);
            Console.WriteLine($"Элементов: {one.Count()}");
            // Тест поиска всех узлов по значению
            two.AddInTail(new Node(15));
            two.AddInTail(new Node(15));
            two.AddInTail(new Node(15));
            Console.WriteLine($"Количество одинаковых элементов:");
            two.FindAll(15);
        }
    }
}


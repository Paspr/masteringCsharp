using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmsDataStructures
{
    class Program
    {
        public class Stack<T>
        {
            readonly LinkedList<T> list = new LinkedList<T>();
            public int Size()
            {
                if (list.Count != 0) return list.Count;
                else
                {
                    return 0;
                }
            }

            public T Pop()
            {
                if (list.Count != 0)
                {
                    T firstElement = list.First.Value;
                    list.RemoveFirst();
                    return firstElement;
                }
                else
                {
                    return default(T);
                }
            }

            public void Push(T val)
            {
                list.AddFirst(val);
            }

            public T Peek()
            {
                if (list.Count != 0)
                {
                    return list.First.Value;
                }
                else
                {
                    return default(T);
                }
            }
        }
        // Circular shift by N elements
        static void TurnQueue(Queue<Object> queue, int item)
        {
            for (int i=0; i < item; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        static void StackEnqueue(Stack<int> first, int item)
        {
            first.Push(item);
        }

        static int StackDequeue(Stack<int> first, Stack<int> second)
        {
            while (first.Size()>0)
            {
                second.Push(first.Peek());
                first.Pop();
            }
            return second.Pop();
        }

        static void Main(string[] args)
        {
            Queue<Object> testQueue = new Queue<Object>();
            testQueue.Enqueue(1);
            testQueue.Enqueue(2);
            testQueue.Enqueue(3);
            testQueue.Dequeue();


            Stack<int> test1 = new Stack<int>();
            Stack<int> test2 = new Stack<int>();
            StackEnqueue(test1, 1);
            StackEnqueue(test1, 2);
            StackEnqueue(test1, 3);
            StackDequeue(test1, test2);
            StackDequeue(test1, test2);
            StackDequeue(test1, test2);
        }
    }
}
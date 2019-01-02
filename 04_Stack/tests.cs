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
        static Boolean IsBalanced(string Brackets)
        {
            Stack<Char> symbols = new Stack<Char>();
            for (int j=0; j < Brackets.Length; j++)
            {
                if (Brackets[j] == '(') symbols.Push(Brackets[j]);
                if (Brackets[j] == ')')
                {
                    if (symbols.Pop() != '(') return false;
                }
            }
            if (symbols.Size()==0) return true;
            else
            {
                return false;
            }
        }

        static double PostfixCalculator(string postfix)
        {
            Stack<char> symbols = new Stack<char>();
            Stack<double> numbers = new Stack<double>();
            double number;
            for (int i = 0; i < postfix.Length; i++)
            {
                if (postfix[i] != ' ') symbols.Push(postfix[i]);
            }
            while (symbols.Size() > 0)
            {
                number = Char.GetNumericValue(symbols.Peek());
                if (number != -1.0)
                {
                    numbers.Push(number);
                    symbols.Pop();
                }
                else
                {
                    if (symbols.Peek() == '=') return numbers.Peek();
                    double first = numbers.Pop();
                    double second = numbers.Pop();
                    switch (symbols.Peek())
                    {
                        case '*':
                            numbers.Push(first*second);
                            symbols.Pop();
                            break;
                        case '+':
                            numbers.Push(first + second);
                            symbols.Pop();
                            break;
                        case '/':
                            numbers.Push(first / second);
                            symbols.Pop();
                            break;
                        case '-':
                            numbers.Push(first - second);
                            symbols.Pop();
                            break;
                        default:
                            break;
                    }
                }
            }
            return numbers.Peek();
        }

        static void Main(string[] args)
        {
            
            Stack<Object> testStack = new Stack<Object>();
            testStack.Push(123);
            testStack.Push("string");
            Console.WriteLine("Peek method test");
            if (Convert.ToInt32(testStack.Peek()) == 123)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Push method test");
            if (Convert.ToInt32(testStack.Pop()) == 123 && testStack.Pop().Equals("string"))
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Size method test");
            if (testStack.Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Pop method test");
            testStack.Push(2.71);
            if (testStack.Pop().Equals(2.71) && testStack.Size() == 0)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("FAIL");
            }
            Console.WriteLine("Input for isBalanced function: ())(");
            Console.Write("Result: ");
            Console.WriteLine(IsBalanced("())("));
            Console.WriteLine("Input for isBalanced function: (()((())()))");
            Console.Write("Result: ");
            Console.WriteLine(IsBalanced("(()((())()))"));
            Console.WriteLine("Input for PostfixCalculator function: 1 2 + 3 *");
            Console.Write("Result: ");
            Console.WriteLine(PostfixCalculator("1 2 + 3 *"));
            Console.WriteLine("Input for PostfixCalculator function: 8 2 + 5 * 9 + =");
            Console.Write("Result: ");
            Console.WriteLine(PostfixCalculator("8 2 + 5 * 9 + ="));
        }
    }
}

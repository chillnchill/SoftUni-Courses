using System;
using System.Collections.Generic;
using System.Linq;

namespace T08_Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> chars = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    chars.Push(input[i]);
                    continue;
                }
                if (chars.Count == 0)
                {
                    isBalanced = false;
                    break;
                }
                else if (chars.Peek() == '(' && input[i] == ')')
                {
                    chars.Pop();
                }
                else if (chars.Peek() == '{' && input[i] == '}')
                {
                    chars.Pop();
                }
                else if (chars.Peek() == '[' && input[i] == ']')
                {
                    chars.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }

            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }


        }
    }
}

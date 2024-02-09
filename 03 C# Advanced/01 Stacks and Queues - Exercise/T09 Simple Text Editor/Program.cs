using System;
using System.Collections.Generic;
using System.Text;

namespace T09_Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfOperations = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            stack.Push(string.Empty);

            for (int i = 0; i < numOfOperations; i++)
            {
                string[] cmndArgs = Console.ReadLine().Split(' ');

                if (cmndArgs[0] == "1")
                {
                    string toAdd = cmndArgs[1];
                    text.Append(toAdd);
                    stack.Push(text.ToString());
                }
                else if (cmndArgs[0] == "2")
                {
                    int toRemove = int.Parse(cmndArgs[1]);
                    text.Length -= toRemove;
                    stack.Push(text.ToString());
                }
                else if (cmndArgs[0] == "3")
                {
                    int index = int.Parse(cmndArgs[1]);
                    if (index >= 0 && index <= text.Length)
                    {
                        char c = text[index - 1];
                        Console.WriteLine(c);
                    }                    
                }
                else if (cmndArgs[0] == "4")
                {
                    stack.Pop();
                    string current = stack.Peek();
                    text = new StringBuilder(current);
                }
            }
        }
    }
}

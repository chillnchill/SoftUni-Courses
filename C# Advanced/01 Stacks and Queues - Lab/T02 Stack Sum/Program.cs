using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>(nums);
            string[] commands = Console.ReadLine().ToLower().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "add")
                {
                    int first = int.Parse(commands[1]);
                    int second = int.Parse(commands[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else
                {
                    int remove = int.Parse(commands[1]);
                    if (remove > stack.Count)
                    {
                        commands = Console.ReadLine().ToLower().Split();
                        continue;
                    }
                    for (int i = 0; i < remove; i++)
                    {
                        stack.Pop();
                    }
                }
                commands = Console.ReadLine().ToLower().Split();
            }
           
           
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

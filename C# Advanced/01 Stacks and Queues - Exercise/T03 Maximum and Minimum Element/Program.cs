using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            

            for (int i = 0; i < n; i++)
            {
                int[] queries = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int commands = queries[0];
                switch (commands)
                {
                    case 1:
                        int toPush = queries[1];
                        stack.Push(toPush);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }


            }
            Console.WriteLine(String.Join(", ", stack));

        }
    }
}

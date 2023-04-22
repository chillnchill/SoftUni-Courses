using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').Reverse().ToArray();          
            var sum = 0;

            Stack<string> stack = new Stack<string>();
                       
            foreach (var thing in input)
            {
                stack.Push(thing);
            }

            var previous = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
               
                var current = stack.Pop();

                if (current == "-")
                {
                    current = stack.Pop();
                    sum =  previous - int.Parse(current);
                    previous = sum;
                }
                else
                {
                    current = stack.Pop();
                    sum = previous + int.Parse(current);
                    previous = sum;
                }
            }
            Console.WriteLine(sum);
        }
    }
}

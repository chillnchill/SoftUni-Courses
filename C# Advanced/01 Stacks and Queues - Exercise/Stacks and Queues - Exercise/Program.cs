using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_and_Queues___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numOfElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            int toPop = nums[1];
            int soughtNumber = nums[2];
            Stack<int> stack = new Stack<int>();

            foreach (int i in numOfElements)
            {
                stack.Push(i);
            }
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(soughtNumber))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count>0)
            {
                Console.WriteLine(stack.Min()); 
            }
            else
            {
                Console.WriteLine(0);
            }
              


           
        }
    }
}

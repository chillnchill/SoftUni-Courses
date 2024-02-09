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

            int toDeque = nums[1];
            int soughtNumber = nums[2];
            Queue<int> que = new Queue<int>();

            foreach (int i in numOfElements)
            {
                que.Enqueue(i);
            }
            for (int i = 0; i < toDeque; i++)
            {
                que.Dequeue();
            }

            if (que.Contains(soughtNumber))
            {
                Console.WriteLine("true");
            }
            else if (que.Count > 0)
            {
                Console.WriteLine(que.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}

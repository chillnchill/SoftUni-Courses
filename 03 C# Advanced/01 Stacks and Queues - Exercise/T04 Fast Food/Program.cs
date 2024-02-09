using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuant = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> que = new Queue<int>(orders);


            foreach (int order in orders)
            {
                if (foodQuant >= que.Peek())
                {
                    foodQuant -= que.Dequeue();
                }
            }

            Console.WriteLine(orders.Max());

            if (que.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", que)}");
            }

        }
    }
}

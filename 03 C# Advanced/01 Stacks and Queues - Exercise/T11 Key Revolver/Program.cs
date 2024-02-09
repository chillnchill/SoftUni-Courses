using System;
using System.Collections.Generic;
using System.Linq;

namespace T11_Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] forBullets = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            Queue<int> bullets = new Queue<int>(forBullets);
            int[] forLock = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            Stack<int> locks = new Stack<int>(forLock);
            
            int totalValue = int.Parse(Console.ReadLine());
            int firedBullets = 0;

            while (bullets.Count > 0)
            {
                          
                if (firedBullets == barrelSize)
                {
                    Console.WriteLine("Reloading!");
                    firedBullets = 0;
                    continue;
                }
                if (locks.Count == 0)
                {
                    break;
                }
                if (bullets.Dequeue() <= locks.Peek())
                {
                    locks.Pop();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                totalValue -= bulletPrice;
                firedBullets++;
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${totalValue}");
            }
            
        }
    }
}

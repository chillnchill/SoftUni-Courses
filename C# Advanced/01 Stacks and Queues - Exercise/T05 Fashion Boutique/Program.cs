using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCounter = 0;
            Stack<int> clthsStck = new Stack<int>(clothes);
            int currentRack = 0;
            
            while (clthsStck.Count > 0)
            {
                currentRack += clthsStck.Peek();

                if (currentRack == rackCapacity && clthsStck.Count != 0)
                {
                    rackCounter++;
                    currentRack = 0;
                }
                else if (currentRack > rackCapacity)
                {
                    rackCounter++;
                    currentRack = clthsStck.Peek();
                }
                clthsStck.Pop();
            }

            if (currentRack > 0)
            {
                rackCounter++;
            }
            Console.WriteLine(rackCounter);

        }
    }
}

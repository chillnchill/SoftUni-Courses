using System;
using System.Collections.Generic;
using System.Linq;

namespace T07_Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<pump> pumpLine = new Queue<pump>();
            int totalDistance = 0;


            for (int i = 0; i < pumps; i++)
            {
                int[] values = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int liters = values[0];
                int distance = values[1];
                pumpLine.Enqueue(new pump(liters, distance));
            }
            int savedTotalDistance = totalDistance;

            for (int i = 0; i < pumpLine.Count; i++)
            {
                bool isItActuallyHeckingOverJesusChristThisTask = true;
                totalDistance = 0;
                for (int j = 0; j < pumpLine.Count; j++)
                {
                    pump current = pumpLine.Peek();
                    totalDistance += current.liters - current.distance;

                    if (totalDistance < 0)
                    {                       
                        isItActuallyHeckingOverJesusChristThisTask = false;                        
                    }                 
                    pumpLine.Enqueue(pumpLine.Dequeue());
                }
                if (isItActuallyHeckingOverJesusChristThisTask)
                {
                    Console.WriteLine(i);
                    break;
                }
                pumpLine.Enqueue(pumpLine.Dequeue());

            }
     
        }

        class pump
        {
            public pump(int liters, int distance)
            {
                this.liters = liters;
                this.distance = distance;
            }

            public int liters { get; set; }
            public int distance { get; set; }
        }
    }
}

using System;
using System.Linq;

namespace T02_The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentPeopleWaiting = int.Parse(Console.ReadLine());
            int[] wagon = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int maxCapacity = wagon.Length * 4;
            int sumOfWagons = 0;
            for (int i = 0; i < wagon.Length; i++)
            {
                for (int j = wagon[i]; j < 4; j++)
                {
                    if (currentPeopleWaiting == 0)
                    {
                        break;
                    }
                    wagon[i]++;
                    currentPeopleWaiting--;
                }
                sumOfWagons+=wagon[i];
            }

            if (sumOfWagons == maxCapacity && currentPeopleWaiting == 0)
            {
                Console.WriteLine(String.Join(" ", wagon));
            }
            else if (sumOfWagons == maxCapacity && currentPeopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {currentPeopleWaiting} people in a queue!");
                Console.WriteLine(String.Join(" ", wagon));
            }
            else if (maxCapacity - sumOfWagons > 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(String.Join(" ", wagon));
            }
            

        }
    }
}

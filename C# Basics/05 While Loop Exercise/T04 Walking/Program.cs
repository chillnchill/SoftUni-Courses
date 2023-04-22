﻿using System;

namespace T04_Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            string input = Console.ReadLine();

            while (input != "Going home")
            {
                steps += int.Parse(input);
                if (steps >= 10000)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "Going home")
            {
                steps += int.Parse(Console.ReadLine());
            }
            if (steps < 10000)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }

        }
    }
}

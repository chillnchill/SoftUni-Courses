using System;
using System.Collections.Generic;

namespace T04_SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Dictionary<string, string> cars = new Dictionary<string, string>();


            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commands = input[0];
                string name = input[1];
                

                switch (commands)
                {
                    case "register":

                        string licensePlateNumber = input[2];

                        if (!cars.ContainsKey(name))
                        {
                            cars.Add(name, licensePlateNumber);
                            Console.WriteLine($"{name} registered {licensePlateNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                        }
                        break;
                    case "unregister":
                        if (cars.ContainsKey(name))
                        {
                            cars.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        break;
                }
            }

            foreach (var pair in cars)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }




        }
    }
}

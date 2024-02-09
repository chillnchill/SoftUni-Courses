using System;
using System.Collections.Generic;

namespace T08_Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            string car = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            
            
            while (car != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < carsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }

                car = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Tax_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split(">>");

            int familyCar = 0;
            int heavyDuty = 0;
            int sports = 0;

            for (int i = 0; i < vehicles.Length; i++)
            {
                string vehicle = vehicles[i];
                string[] currentVehicle = vehicle.Split(' ');

                int yearsInUse = int.Parse(currentVehicle[1]);
                int kmTraveled = int.Parse(currentVehicle[2]);

                switch (currentVehicle[0])
                {
                    case "family":
                        int currentCar = (kmTraveled / 3000) * 12 + (50 - (yearsInUse * 5));
                        familyCar += currentCar;
                        Console.WriteLine($"A family car will pay {currentCar:f2} euros in taxes.");
                        break;
                    case "heavyDuty":
                        int currentHeavy = (kmTraveled / 9000) * 14 + (80 - (yearsInUse * 8));
                        heavyDuty += currentHeavy;
                        Console.WriteLine($"A heavyDuty car will pay {currentHeavy:f2} euros in taxes.");
                        break;
                    case "sports":
                        int currentSports = (kmTraveled / 2000) * 18 + (100 - (yearsInUse * 9));
                        sports += currentSports;
                        Console.WriteLine($"A sports car will pay {currentSports:f2} euros in taxes.");
                        break;
                    default:
                        Console.WriteLine("Invalid car type.");
                        break;
                }

            }


            Console.WriteLine($"The National Revenue Agency will collect {familyCar+heavyDuty+sports:f2} euros in taxes.");
            
        }
    }
}

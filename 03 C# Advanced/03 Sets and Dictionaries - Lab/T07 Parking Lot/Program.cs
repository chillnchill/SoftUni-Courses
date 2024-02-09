using System;
using System.Collections.Generic;

namespace T07_Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> licensePlate = new HashSet<string>();

            while (true)
            {
                string[] intput = Console.ReadLine().Split(", ");
                
                if (intput[0] == "END")
                {
                    break;
                }

                string action = intput[0];
                string plate = intput[1];

                if (action == "IN")
                {
                    licensePlate.Add(plate);
                }
                else
                {
                    licensePlate.Remove(plate);
                }
            }
            if (licensePlate.Count > 0)
            {
                foreach (string plate in licensePlate)
                {
                    Console.WriteLine(plate);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

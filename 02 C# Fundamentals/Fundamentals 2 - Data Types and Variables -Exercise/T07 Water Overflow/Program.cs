using System;

namespace T07_Water_Overflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaterDoses = int.Parse(Console.ReadLine());           
            int totalCapacity = 255;
            int currentLiters = 0;

            for (int i = 0; i < numberOfWaterDoses; i++)
            {
                int litersPerDose = int.Parse(Console.ReadLine());
                
                if (currentLiters + litersPerDose <= totalCapacity)
                {
                    currentLiters += litersPerDose;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(currentLiters);

            //this task would've been a heck of an easier to do if i knew about "const int"

        }
    }
}

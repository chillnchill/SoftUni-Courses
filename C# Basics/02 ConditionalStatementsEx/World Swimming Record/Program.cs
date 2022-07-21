using System;

namespace World_Swimming_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeteres = double.Parse(Console.ReadLine());
            double metersInSeconds = double.Parse(Console.ReadLine());

            
            double secondsNeeded = distanceMeteres * metersInSeconds;
            double resistance = Math.Floor(distanceMeteres / 15) * 12.5;
            double total = secondsNeeded + resistance;
            double timeNeeded = Math.Abs(recordSeconds - total);

            if (recordSeconds > total)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {total:F2} seconds.");
            }
            else if (recordSeconds <= total)
            {
                Console.WriteLine($"No, he failed! He was {timeNeeded:F2} seconds slower.");
            }
        }
    }
}

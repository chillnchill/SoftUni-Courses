using System;

namespace T07_Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            int additionalPoints = 0;
            double w = 0;
            



            for (int i = 0; i < tournaments; i++)
            {
                string finish = Console.ReadLine();

                if (finish == "W")
                {
                    additionalPoints += 2000;
                }
                else if (finish == "F")
                {
                    additionalPoints += 1200;
                }
                else if (finish == "SF")
                {
                    additionalPoints += 720;
                }

                if (finish == "W")
                {
                    w++;
                }

            }
            
            double winPercent = w / tournaments * 100;
            double allPoints = startingPoints + additionalPoints;
            double averagePoints = additionalPoints / tournaments;

            Console.WriteLine($"Final points: {allPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{winPercent:f2}%");

        }
    }
}


using System;
using System.Numerics;

namespace T11_Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger snowballSnow = 0;
            BigInteger snowballTime = 0;
            int snowballQuality = 0;
            BigInteger bestSnowball = 0;

            for (int counter = 0; counter < numberOfSnowballs; counter++)
            {
                BigInteger currentSnowballSnow = int.Parse(Console.ReadLine());
                BigInteger currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);

                if (snowballValue > bestSnowball)
                {
                    bestSnowball = snowballValue;
                    snowballSnow = currentSnowballSnow;
                    snowballTime = currentSnowballTime;
                    snowballQuality = currentSnowballQuality;
                }

            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {bestSnowball} ({snowballQuality})");

        }
    }
}

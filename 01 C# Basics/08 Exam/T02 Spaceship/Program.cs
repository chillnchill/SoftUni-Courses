using System;

namespace T02_Spaceship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLength = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double averagePersonHeight = double.Parse(Console.ReadLine());


            double shipVolume = shipHeight * shipLength * shipWidth;
            double roomVolume = (averagePersonHeight + 0.40) * 4;
            double peopleCapacity = Math.Floor(shipVolume / roomVolume);

            if (peopleCapacity >= 3 && peopleCapacity <= 10)
            {
                Console.WriteLine($"The spacecraft holds {peopleCapacity} astronauts.");
            }
            else if (peopleCapacity < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }

        }
    }
}

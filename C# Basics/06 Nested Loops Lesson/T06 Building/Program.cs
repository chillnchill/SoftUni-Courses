using System;

namespace T06_Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfFloors = int.Parse(Console.ReadLine());
            int numberOfRooms = int.Parse(Console.ReadLine());

            for (int floorNumber = numberOfFloors; floorNumber >= 1; floorNumber--)
            {
                for (int roomNumber = 0; roomNumber < numberOfRooms; roomNumber++)
                {
                    if (floorNumber == numberOfFloors)
                    {
                        Console.Write($"L{floorNumber}{roomNumber} ");
                    }
                    else if (floorNumber % 2 == 0)
                    {
                        Console.Write($"O{floorNumber}{roomNumber} ");
                    }
                    else
                    {
                        Console.Write($"A{floorNumber}{roomNumber} ");
                    }
                }
                Console.WriteLine();
            }


        }
    }
}

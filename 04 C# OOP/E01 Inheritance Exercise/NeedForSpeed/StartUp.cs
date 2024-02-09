using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar sportCar = new SportCar(100, 100);

            sportCar.Drive(10.5);

            Console.WriteLine(sportCar.Fuel);

             


        }
    }
}

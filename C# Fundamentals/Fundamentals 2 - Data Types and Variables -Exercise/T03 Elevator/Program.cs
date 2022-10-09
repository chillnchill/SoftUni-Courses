using System;

namespace T03_Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double numberOfPeople = int.Parse(Console.ReadLine());
           double elevatorCapacity = int.Parse(Console.ReadLine());

           double numberOfCourses = Math.Ceiling(numberOfPeople / elevatorCapacity);

           Console.WriteLine(numberOfCourses);
        }
    }
}

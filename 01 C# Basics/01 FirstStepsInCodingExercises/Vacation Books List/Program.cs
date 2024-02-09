using System;

namespace Vacation_Books_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesPerHr = int.Parse(Console.ReadLine());
            int numberOfDays = int.Parse(Console.ReadLine());

            
            int totalHr = numberOfPages / pagesPerHr;
            int hoursPerDay = totalHr / numberOfDays;


            Console.WriteLine(hoursPerDay);
        }

    }
}

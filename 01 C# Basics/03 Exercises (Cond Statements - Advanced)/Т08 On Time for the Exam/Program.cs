using System;

namespace Т08_On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHr = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHr = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            examMin = examMin + examHr * 60;
            arrivalMin = arrivalMin + arrivalHr * 60;

            int difference = examMin - arrivalMin;


            if (difference < 0)
            {
                Console.WriteLine("Late");
            }
            else if (difference >= 0 && difference <= 30)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Early");
            }

            int diffHr = Math.Abs(difference / 60);
            int diffMin = Math.Abs(difference % 60);

            if (difference > 0 && difference <= 59)
            {
                Console.WriteLine($"{difference} minutes before the start");
            }
            else if (difference >= 60)
            {
                if (diffMin < 10)
                {
                    Console.WriteLine($"{diffHr}:0{diffMin} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{diffHr}:{diffMin} hours before the start");
                }
            }
            else if (difference < 0 && difference >= -59)
            {
                Console.WriteLine($"{Math.Abs(difference)} minutes after the start");
            }
            else if (difference <= -60)
            {
                if (diffMin < 10)
                {
                    Console.WriteLine($"{diffHr}:0{diffMin} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{diffHr}:{diffMin} hours after the start");
                }
            }

        }
    }
}

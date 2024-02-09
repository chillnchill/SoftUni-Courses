using System;

namespace Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeHr = int.Parse(Console.ReadLine());
            int timeMin = int.Parse(Console.ReadLine());

            timeHr = timeHr * 60;

            int time = timeHr + timeMin + 15;



            double hr = (time / 60);
            double min = (time % 60);

            //this can also be "if hr > 23 -> hr = 0"
            if (hr >= 24)
            {
                hr = hr - 24;
            }
            
            

                if (min < 10)
                {
                    Console.WriteLine($"{hr}:0{min}", "{ 0:F2}");
                }
                else
                {
                    Console.WriteLine($"{hr}:{min}", "{ 0:F2}");
                }
            
            
            

        }
    }
}

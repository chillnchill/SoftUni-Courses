using System;

namespace BugSquasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int allEggs = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            int max = 0;
            string maxColor = "";

            for (int i = 0; i < allEggs; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    red++;
                   if (red > max)
                    {
                        max = red;
                        maxColor = "red";
                    }
                }
                if (color == "orange")
                {
                    orange++;
                    if (orange > max)
                    {
                        max = orange;
                        maxColor = "orange";
                    }
                }
                if (color == "blue")
                {
                    blue++;
                    if (blue > max)
                    {
                        max = blue;
                        maxColor = "blue";
                    }
                }
                if (color == "green")
                {
                    green++;
                    if (green > max)
                    {
                        max = green;
                        maxColor = "green";
                    }
                }
            }

           
            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {max} -> {maxColor}");
        
        }
    }
}

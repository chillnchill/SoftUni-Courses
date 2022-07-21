using System;

namespace T02_Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            string outfit = "";
            string shoes = "";


            switch (timeOfDay)
            {
                case "Morning":
                    if (10 <= degrees && degrees <= 18)
                    {
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (18 < degrees && degrees <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else 
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                    break;

                case "Afternoon":
                    if (10 <= degrees && degrees <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < degrees && degrees <= 24)
                    {
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else 
                    {
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                    break;
                case "Evening":
                    if (10 <= degrees && degrees <= 18)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < degrees && degrees <= 24)
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    else 
                    {
                        outfit = "Shirt";
                        shoes = "Moccasins";
                    }
                    Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
                    break;
            }
        }
    }
}

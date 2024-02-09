using System;

namespace T03_Football_Souvenirs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirType = Console.ReadLine();
            int souvenirCount = int.Parse(Console.ReadLine());
            double price = 0;

            switch (team)
            {
                case "Argentina":
                    switch (souvenirType)
                    {
                        case "flags":
                            price = souvenirCount * 3.25;
                            break;
                        case "caps":
                            price = souvenirCount * 7.20;
                            break;
                        case "posters":
                            price = souvenirCount * 5.10;
                            break;
                        case "stickers":
                            price = souvenirCount * 1.25;
                            break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;
                case "Brazil":
                    switch (souvenirType)
                    {
                        case "flags":
                            price = souvenirCount * 4.20;
                            break;
                        case "caps":
                            price = souvenirCount * 8.50;
                            break;
                        case "posters":
                            price = souvenirCount * 5.35;
                            break;
                        case "stickers":
                            price = souvenirCount * 1.20;
                            break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;
                case "Croatia":
                    switch (souvenirType)
                    {
                        case "flags":
                            price = souvenirCount * 2.75;
                            break;
                        case "caps":
                            price = souvenirCount * 6.90;
                            break;
                        case "posters":
                            price = souvenirCount * 4.95;
                            break;
                        case "stickers":
                            price = souvenirCount * 1.10;
                            break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;
                case "Denmark":
                    switch (souvenirType)
                    {
                        case "flags":
                            price = souvenirCount * 3.10;
                            break;
                        case "caps":
                            price = souvenirCount * 6.50;
                            break;
                        case "posters":
                            price = souvenirCount * 4.80;
                            break;
                        case "stickers":
                            price = souvenirCount * 0.90;
                            break;
                        default:
                            Console.WriteLine("Invalid stock!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid country!");
                    break;


            }
            if (price > 0)
            {
                Console.WriteLine($"Pepi bought {souvenirCount} {souvenirType} of {team} for {price:f2} lv.");
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}

using System;

namespace T07_Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coin = (Console.ReadLine());
            double total = 0;



            while (coin != "Start")
            {
                double digitized = double.Parse(coin);

                if (digitized != 0.1 && digitized != 0.2 && digitized != 0.5 && digitized != 1 && digitized != 2)
                {
                    Console.WriteLine($"Cannot accept {digitized}");
                  
                }
                else
                {
                    total += digitized;
                }


                coin = (Console.ReadLine());

            }

            coin = (Console.ReadLine());




            while (coin != "End")
            {
                if (coin != "Nuts" && coin != "Water" && coin != "Crisps" && coin != "Soda" && coin != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }
                else
                {
                    if (coin == "Nuts" && total >= 2.0)
                    {
                        total -= 2.0;
                        Console.WriteLine($"Purchased nuts");
                    }
                    else if (coin == "Water" && total >= 0.7)
                    {
                        total -= 0.7;
                        Console.WriteLine($"Purchased water");
                    }
                    else if (coin == "Crisps" && total >= 1.5)
                    {
                        total -= 1.5;
                        Console.WriteLine($"Purchased crisps");
                    }
                    else if (coin == "Soda" && total >= 0.8)
                    {
                        total -= 0.8;
                        Console.WriteLine($"Purchased soda");
                    }
                    else if (coin == "Coke" && total >= 1.0)
                    {
                        total -= 1.0;
                        Console.WriteLine($"Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                

                coin = (Console.ReadLine());
            }
            if (total < 0)
            {
                total = 0;
            }
            Console.WriteLine($"Change: {total:f2}");
        }
    }
}

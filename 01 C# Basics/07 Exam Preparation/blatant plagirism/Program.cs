using System;

namespace blatant_plagirism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());
            //тези да са празни стойности
            double basket = 0;
            double wreath = 0;
            double chocolateBunny = 0;
            double totalPrice = 0;

            for (int i = 0; i < customers; i++)
            {
                string purchases = Console.ReadLine();

                while (purchases != "Finish")
                {
                    //тези ще бъдат с IF проверки и с разграфените цени
                    if (purchases == "basket")
                    {
                        basket++;
                    }
                    else if (purchases == "wreath")
                    {
                        wreath++;
                    }
                    else if (purchases == "chocolate bunny")
                    {
                        chocolateBunny++;
                    }
                    purchases = Console.ReadLine();
                }
                double sum = basket + wreath + chocolateBunny;


                basket *= 1.50;
                wreath *= 3.80;
                chocolateBunny *= 7.00;

                double pricePerClient = basket + wreath + chocolateBunny;

                if (sum % 2 == 0)
                {
                    pricePerClient *= 0.80;
                }

                totalPrice += pricePerClient;
                Console.WriteLine($"You purchased {sum} items for {pricePerClient:f2} leva.");

                if (purchases == "Finish")
                {
                    basket = 0;
                    wreath = 0;
                    chocolateBunny = 0;
                }

            }

                Console.WriteLine($"Average bill per client is: {totalPrice / customers:f2} leva.");

            
        }
    }
}

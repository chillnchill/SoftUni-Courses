using System;

namespace T05_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double coin = double.Parse(Console.ReadLine());
            coin *= 100;
            int change = 0;


            while (coin > 0)
            {
                if (coin >= 200)
                {
                    change++;
                    coin -= 200;

                }
                else if (coin >= 100)
                {
                    change++;
                    coin -= 100;

                }
                else if (coin >= 50)
                {
                    change++;
                    coin -= 50;

                }
                else if (coin >= 20)
                {
                    change++;
                    coin -= 20;

                }
                else if (coin >= 10)
                {
                    change++;
                    coin -= 10;

                }
                else if (coin >= 5)
                {
                    change++;
                    coin -= 5;

                }
                else if (coin >= 2)
                {
                    change++;
                    coin -= 2;
                    
                }
                else if (coin >= 1)
                {
                    change++;
                    coin -= 1;
                    
                }
                else
                {
                    coin = 0;
                }

            }
            Console.WriteLine(change);
        }
    }
}

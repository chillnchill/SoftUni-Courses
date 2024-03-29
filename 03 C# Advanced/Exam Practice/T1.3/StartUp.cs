﻿using System;

namespace StockMarket
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Sample Code Usage:

            // Initialize Investor
            Investor investor = new Investor("Peter Lynch", "p.lynch@gmail.com", 2000m, "Fidelity");

            // Initialize Stock
            Stock ibmStock = new Stock("IBM", "Arvind Krishna", 150.50m, 5000);

            // Print a stock
            Console.WriteLine(ibmStock);

            // Company: IBM
            // Director: Arvind Krishna
            // Price per share: $138.50
            // Market capitalization: $692500.00

            // Buy a stock
            investor.BuyStock(ibmStock);

            // Sell a stock
            Console.WriteLine(investor.SellStock("Buba", 150.00m)); // "IBM was sold."
                                                                   // Add stocks
            Stock teslaStock = new Stock("Tesla", "Elon Musk", 743.17m, 6520);
            Stock amazonStock = new Stock("Amazon", "Jeff Bezos", 3457.17m, 8500);
            Stock twitterStock = new Stock("Twitter", "Jack Dorsey", 59.66m, 11200);
            Stock blizzardStock = new Stock("Activision Blizzard", "Bobby Kotick", 78.53m, 5520);

            // Buy more stocks
            investor.BuyStock(teslaStock);
            investor.BuyStock(amazonStock);
            investor.BuyStock(twitterStock);
            investor.BuyStock(blizzardStock);

            Console.WriteLine(investor.SellStock("Activision Blizzard", 150.00m));

            Console.WriteLine(investor.FindStock("Activision"));

            // FindBiggestCompany
            Console.WriteLine(investor.FindBiggestCompany());

            // Company: Tesla
            // Director: Elon Musk
            // Price per share: $743.17
            // Market capitalization: $4845468.40
            Console.WriteLine(investor.Count);
            Console.WriteLine("=====================================");
            // Print investor information
            Console.WriteLine(investor.InvestorInformation());

            // The investor Peter Lynch with a broker Fidelity has stocks:
            // Company: Tesla
            // Director: Elon Musk
            // Price per share: $743.17
            // Market capitalization: $4845468.40
            // Company: Twitter
            // Director: Jack Dorsey
            // Price per share: $59.66
            // Market capitalization: $668192.00
            // Company: Activision Blizzard
            // Director: Bobby Kotick
            // Price per share: $78.53
            // Market capitalization: $433485.60
        }
    }
}

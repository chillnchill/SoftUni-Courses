using System;
using System.Collections.Generic;

namespace T03_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productPrice = new Dictionary<string, double>();

            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            string[] products = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (products[0] != "buy")
            {
                string product = products[0];
                double price = double.Parse(products[1]);
                int quantity = int.Parse(products[2]);

                if (!productPrice.ContainsKey(product))
                {
                    productPrice.Add(product, price);
                    productQuantity.Add(product, quantity);
                }
                else if (productPrice.ContainsKey(product))
                {
                    productPrice.Remove(product);
                    productPrice.Add(product, price);
                    productQuantity[product] += quantity;
                }
                products = products = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var itemPrice in productPrice)
            {
                foreach (var itemQuant in productQuantity)
                {
                    if (itemPrice.Key == itemQuant.Key)
                    {
                        Console.WriteLine($"{itemPrice.Key} -> {itemPrice.Value * itemQuant.Value:f2}");
                    }
                }
            }
        }
    }
}

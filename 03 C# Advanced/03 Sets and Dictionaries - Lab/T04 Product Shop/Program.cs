using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, double>> products = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ");

                if (input[0] == "Revision")
                {
                    break;
                }

                string store = input[0];
                string productType = input[1];
                double price = double.Parse(input[2]);


                if (!products.ContainsKey(store))
                {
                    products.Add(store, new Dictionary<string, double>());
                }

                products[store].Add(productType, price);

            }

            products = products
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var store in products)
            {
                var productPrice = store.Value;
                Console.WriteLine($"{store.Key}->");
                foreach (var product in productPrice)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
                
            }
        }
    }
}

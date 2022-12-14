using System;
using System.Collections.Generic;

namespace T02_A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mineral = Console.ReadLine();
            Dictionary<string, int> logBook = new Dictionary<string, int>();

            while (mineral != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (logBook.ContainsKey(mineral))
                {
                    logBook[mineral] += quantity;
                }
                else
                {
                    logBook.Add(mineral, quantity);
                }

                mineral = Console.ReadLine();
            }

            foreach (var pair in logBook)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Monthly_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var distributorMoney = new Dictionary<string, double>();
            var clientMoney = new Dictionary<string, double>();

            while (commands[0] != "End")
            {
                switch (commands[0])
                {
                    case "Deliver":
                        { 
                        string distributor = commands[1];
                        double money = double.Parse(commands[2]);
                        if (!distributorMoney.ContainsKey(distributor))
                        {
                            distributorMoney.Add(distributor, money);
                        }
                        else
                        {
                            distributorMoney[distributor] += money;
                        }
                        }
                        break;
                    case "Return":
                        {
                            string distributor = commands[1];
                            double money = double.Parse(commands[2]);

                            if (distributorMoney.ContainsKey(distributor))
                            {
                                if (distributorMoney[distributor] >= money)
                                {
                                    distributorMoney[distributor] -= money;
                                }
                                if (distributorMoney[distributor] == 0)
                                {
                                    distributorMoney.Remove(distributor);
                                }
                            }
                        }
                        break;
                    case "Sell":
                        string client = commands[1];
                        double moneyEarned = double.Parse(commands[2]);
                        if (!clientMoney.ContainsKey(client))
                        {
                            clientMoney.Add(client,  moneyEarned);
                        }
                        else
                        {
                            clientMoney[client] += moneyEarned; 
                        }
                        break;
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            double totalEarned = 0;
            foreach (var client in clientMoney)
            {
                Console.WriteLine($"{client.Key}: {client.Value:f2}");
                totalEarned += clientMoney[client.Key];
            }
            Console.WriteLine("-----------");
            foreach (var distributor in distributorMoney)
            {
                Console.WriteLine($"{distributor.Key}: {distributor.Value:f2}");   
            }
            Console.WriteLine("-----------");

            Console.WriteLine($"Total Income: {totalEarned:f2}");
        }
    }
}

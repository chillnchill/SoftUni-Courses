using System;
using System.Collections.Generic;
using System.Linq;

namespace T00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var employees = new Dictionary<string, List<string>>();

            string[] commands = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                string company = commands[0];
                string emp = commands[1];

                if (!employees.ContainsKey(company))
                {
                    employees.Add(company, new List<string>{ emp });
                }
                else
                {
                    if (employees[company].Contains(emp))
                    {
                        commands = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        employees[company].Add(emp);
                    }
                }

                commands = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }


            foreach (var (key, value) in employees)
            {
                Console.WriteLine($"{key}");
                foreach (var item in value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}

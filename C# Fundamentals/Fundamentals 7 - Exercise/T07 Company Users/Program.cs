using System;
using System.Collections.Generic;

namespace T07_Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ");
            
            Dictionary<string, List<string>> employeeCredential = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string companyName = input[0];
                var employeeID = input[1];

                if (!employeeCredential.ContainsKey(companyName))
                {
                    employeeCredential.Add(companyName, new List<string>());
                    employeeCredential[companyName].Add(employeeID);                      
                }
                if (!employeeCredential[companyName].Contains(employeeID))
                {
                    employeeCredential[companyName].Add(employeeID);
                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var pair in employeeCredential)
            {
                string company = pair.Key;
                var ID = pair.Value;

                Console.WriteLine(company);
                
                foreach (var item in ID)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}

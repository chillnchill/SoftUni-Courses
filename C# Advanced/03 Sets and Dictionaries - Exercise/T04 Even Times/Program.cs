using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> element = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int n = int.Parse(Console.ReadLine());
                
                if (!element.ContainsKey(n))
                {
                    element.Add(n, 1);
                }
                else
                {
                    element[n]++;
                }

            }

            Console.WriteLine(element.Single(x => x.Value % 2 == 0).Key);
        }
    }
}

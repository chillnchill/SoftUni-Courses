using System;
using System.Collections.Generic;
using System.Linq;

namespace T01_Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> keyValuePairs = new Dictionary<double, int>();


            foreach (var num in input)
            {
                if (!keyValuePairs.ContainsKey(num))
                {
                    keyValuePairs.Add(num, 1);
                }
                else
                {
                    keyValuePairs[num]++;
                }
            }
            
            foreach (var pair in keyValuePairs)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}

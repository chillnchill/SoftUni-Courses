using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> element = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] stringedElements = Console.ReadLine().Split(" ");
                foreach (string el in stringedElements)
                {
                    element.Add(el);
                }
            }

            element = element
                .OrderBy(x => x)
                .ToHashSet();

            foreach (string el in element)
            {
                Console.Write($"{el} ");
            }
        }
    }
}

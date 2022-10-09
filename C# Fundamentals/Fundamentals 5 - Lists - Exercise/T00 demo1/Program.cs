using System;
using System.Collections.Generic;
using System.Linq;

namespace T00_demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mainList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> dividedParts = new List<string>();
            string toBeDivided = mainList[0];
            int parts = 2;
            int partitions = 3;

            for (int i = 0; i < partitions; i++)
            {
                //finding last part of parted string
                if (i == partitions - 1)
                {
                    dividedParts.Add(toBeDivided.Substring(i * parts));
                }
                //separating the first parts into equals
                else
                {
                    dividedParts.Add(toBeDivided.Substring(i * parts, parts));
                }

            }
        }
    }
}

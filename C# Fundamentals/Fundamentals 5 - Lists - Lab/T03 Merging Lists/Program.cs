using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numsOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numsTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = new List<int>();

            int biggerList = Math.Max(numsOne.Count, numsTwo.Count);

            for (int i = 0; i < biggerList; i++)
            {
                if (numsOne.Count > i)
                {
                    resultList.Add(numsOne[i]);
                }
                if (numsTwo.Count > i)
                {
                    resultList.Add(numsTwo[i]);
                }  
            }

            Console.WriteLine(String.Join(" ", resultList));

        }
    }
}

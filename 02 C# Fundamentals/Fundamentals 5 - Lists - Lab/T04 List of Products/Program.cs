using System;
using System.Collections.Generic;

namespace T04_List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int listCount = int.Parse(Console.ReadLine());
            List<string> groceryList = new List<string>();

            for (int i = 0; i < listCount; i++)
            {
                string grocery = Console.ReadLine();

                groceryList.Add(grocery);
            }
            groceryList.Sort();

            int count = 1;

            for (int i = 0; i < listCount; i++)
            {
                Console.WriteLine($"{count}.{groceryList[i]}");
                count++;
            }
            
        }
    }
}

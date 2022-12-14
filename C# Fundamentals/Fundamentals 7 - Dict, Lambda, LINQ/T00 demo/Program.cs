using System;
using System.Collections.Generic;

namespace T00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook["0865151007"] = "George";
            phoneBook["0865153467"] = "Dork";

            foreach (var item in phoneBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }


            int[] nums = new int[5];



        }
    }
}

using System;

namespace T04_Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();

            string[] items = values.Split(' ');

            
            
            for (int i = items.Length - 1; i >= 0; i--)
            {
                Console.Write($"{items[i]} ");
            }

                
        }
    }
}

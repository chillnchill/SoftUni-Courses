using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bomb = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            

            for (int i = 0; i < numbers.Count; i++)
            {
                
                if (numbers[i] == bomb[0])
                {
                    int start = i - bomb[1];
                    int end = i + bomb[1];

                    if (start < 0)
                    {
                        start = 0;
                    }
                    if (end > numbers.Count - 1)
                    {
                        end = numbers.Count - 1;
                    }

                    for (int j = start; j <= end; j++)
                    {
                        numbers[j] = 0;
                    }
                }


            }
            Console.WriteLine(numbers.Sum());

        }
    }
}


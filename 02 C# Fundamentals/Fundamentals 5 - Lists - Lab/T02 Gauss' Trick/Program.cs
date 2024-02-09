using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int counter = 0;

            for (int index = nums.Count - 1; index > counter; index--)
            {
                if (counter == index)
                {
                    break;
                }
                nums[counter] += nums[index];
                nums.RemoveAt(index);
                counter++;

            }

            Console.WriteLine(String.Join(" ", nums));
        }
    }
}

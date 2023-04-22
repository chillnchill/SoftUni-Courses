using System;
using System.Linq;

namespace T03_Custom_MIn_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = x => x.Min();

            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(minNumber(nums));
        }
    }
}

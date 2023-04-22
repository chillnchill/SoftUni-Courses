using System;

namespace T04_Sequence_2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;

            while (n >= sum)

            {
                Console.WriteLine(sum);
                sum = sum * 2 + 1;
                if (sum > n)
                {
                    break;
                }

            }


        }
    }
}

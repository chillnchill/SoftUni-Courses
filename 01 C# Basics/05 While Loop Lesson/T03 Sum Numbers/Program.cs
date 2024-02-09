using System;

namespace T02_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            while (startingNumber > sum)
            {
                int nextNumber = int.Parse(Console.ReadLine());
                sum += nextNumber;
                
            }
            Console.WriteLine(sum);
        }
    }
}

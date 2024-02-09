using System;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int snowballSnow = int.Parse(Console.ReadLine());
            int snowballTime = int.Parse(Console.ReadLine());
            int snowballQuality = int.Parse(Console.ReadLine());

            int result = (int)Math.Pow((snowballSnow / snowballTime), snowballQuality);

            Console.WriteLine(result);


        }
    }
}

using System;

namespace USD_to_BGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double parse takes the text from the console and turns it to a fragment number. Ex. from text 22 to the number 22
            double usd = double.Parse(Console.ReadLine());

            double bgn = usd * 1.79549;

            Console.WriteLine(bgn);
        }
    }
}

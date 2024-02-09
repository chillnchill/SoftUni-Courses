using System;

namespace Т01_Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Action<string[]> splitter = strings =>
            Console.WriteLine(string.Join(Environment.NewLine, strings));

            string[] input = Console.ReadLine().Split(' ');

            splitter(input);
        }
    }
}

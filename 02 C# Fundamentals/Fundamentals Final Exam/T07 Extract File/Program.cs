using System;

namespace T07_Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '\\', '.' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {input[input.Length - 2]}");
            Console.WriteLine($"File extension: {input[input.Length-1]}");
        }
    }
}

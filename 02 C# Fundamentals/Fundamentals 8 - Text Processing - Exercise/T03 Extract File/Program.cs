using System;
using System.Linq;

namespace T03_Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fileLocation = Console.ReadLine().Split('.');
            var name = fileLocation[0].Split('\\');
            string file = name[name.Length-1];
            string extension = fileLocation[1];

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");

        }

    }

}

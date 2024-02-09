using System;

namespace T01_Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Console.WriteLine(n <= 2 ? "baby" : n > 2 && n <= 13 ? "child" : n > 13 && n <= 19 ? "teenager" : n > 19 && n <= 65 ? "adult" : "elder");



        }
    }
}

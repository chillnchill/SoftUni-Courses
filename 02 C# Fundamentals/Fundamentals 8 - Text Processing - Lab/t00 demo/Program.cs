using System;
using System.Diagnostics;

namespace t00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string initial = Console.ReadLine();
            string newStr = "";

            while (initial != "end")
            {
                for (int i = initial.Length - 1; i >= 0; i--)
                {
                    newStr += initial[i];
                }
                Console.WriteLine($"{initial} = {newStr}");
                newStr = "";
                initial = Console.ReadLine();
            }

            

            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //string text = "";
            //for (int i = 0; i < 200000; i++)
            //    text += i;
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}

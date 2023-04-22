using System;
using System.Collections.Generic;
using System.IO;

namespace T03_Word_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string soughtWords = Console.ReadLine();
            Dictionary<string, int> soughtWordCount = new Dictionary<string, int>();

            StreamReader soughtWord = new StreamReader(soughtWords)
            {

            };
        }
    }
}

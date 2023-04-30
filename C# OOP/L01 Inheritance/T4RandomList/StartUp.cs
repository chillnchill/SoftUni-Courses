using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList strings = new RandomList();

            strings.Add("1");
            strings.Add("2");
            strings.Add("3");
            strings.Add("4");

            Console.WriteLine(strings.RandomString());
        }
    }
    
}

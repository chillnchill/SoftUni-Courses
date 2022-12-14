using System;
using System.Linq;

namespace T03_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toFind = Console.ReadLine();
            string jibberish = Console.ReadLine();
           
            

            while (jibberish.Contains(toFind))
            {
                int index = jibberish.IndexOf(toFind);
                jibberish = jibberish.Remove(index, toFind.Length);
            }


            Console.WriteLine(jibberish);
            
            

        }
    }
}

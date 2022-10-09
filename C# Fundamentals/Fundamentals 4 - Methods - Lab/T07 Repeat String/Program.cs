using System;
using System.Text;

namespace T07_Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toBeRepeated = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            RepeatString(toBeRepeated, repeats);
            Console.WriteLine(RepeatString(toBeRepeated, repeats));
            
        }

        private static string RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }
               
            return result.ToString();
        }
    }

}


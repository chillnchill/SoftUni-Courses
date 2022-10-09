using System;

namespace T08_Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string currentBiggestKeg = "";
            double currentBiggestVolume = 0;

            for (int i = 0; i < numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;
                if (volume > currentBiggestVolume)
                {
                    currentBiggestVolume = volume;
                    currentBiggestKeg = model;
                }
                volume = 0;
            }
            Console.WriteLine(currentBiggestKeg);
            
        }
    }
}

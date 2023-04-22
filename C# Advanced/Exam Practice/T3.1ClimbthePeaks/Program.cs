using System;
using System.Collections.Generic;
using System.Linq;

namespace T3._1ClimbthePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodPortions = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Queue<int> staminaReserves = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            List<string> conqueredPeaks = new List<string>(); 
            Dictionary<string, int> peaks = new Dictionary<string, int>();
            bool didHe = false;
            peaks.Add("Vihren", 80);
            peaks.Add("Kutelo", 90);
            peaks.Add("Banski Suhodol", 100);
            peaks.Add("Polezhan", 60);
            peaks.Add("Kamenitza", 70);

            while (foodPortions.Count > 0 && staminaReserves.Count > 0)
            {
                int energy = foodPortions.Pop() + staminaReserves.Dequeue();
                int currentPeak = peaks.Values.First();
                if (energy >= currentPeak)
                {
                    conqueredPeaks.Add(peaks.Keys.First());
                    peaks.Remove(peaks.Keys.First());

                }
                if (peaks.Count == 0)
                {
                    didHe = true;
                    break;
                }
            }
            if (didHe)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }            
            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var conqueredPeak in conqueredPeaks)
                {
                    Console.WriteLine(conqueredPeak);
                }                   
            }
        }
    }
}

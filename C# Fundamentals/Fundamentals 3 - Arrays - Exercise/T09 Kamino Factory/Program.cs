using System;
using System.Linq;

namespace T09_Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initial input == DNA length
            int sequenceLength = int.Parse(Console.ReadLine());
            //a string to get the while cycle to work
            string input = Console.ReadLine();
            //a new array which will contain the best DNA from the given sequences
            int[] bestDNA = new int[sequenceLength];
            //variables to track the needed data
            int longestSequence = -1;
            int bestDNASequence = -1;
            int biggestSum = 0;
            int leftMostIndex = 0;
            int leftMostIndexSoFar = 0;
            int currentSequence = 0;
            

            while (input != "Clone them!")
            {

                int[] currentDNA = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currentLongestSequence = 0;
                int currentSum = 0;
                int currentLeftMostIndex = 0;
                int longestSequenceSoFar = 0;
                currentSequence++;
                bool isBestDNA = false;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    currentSum += currentDNA[i];

                    if (currentDNA[i] == 1)
                    {
                        currentLongestSequence++;
                    }
                    else
                    {
                        currentLongestSequence = 0;
                    }
                    if (currentLongestSequence > longestSequenceSoFar)
                    {
                        longestSequenceSoFar = currentLongestSequence;
                        currentLeftMostIndex = i - (currentLongestSequence + 1);
                        leftMostIndexSoFar = currentLeftMostIndex;
                    }

                }
                if (longestSequenceSoFar > longestSequence)
                {
                    isBestDNA = true;                   
                }
                else if (longestSequenceSoFar == longestSequence)
                {
                    if (leftMostIndexSoFar < leftMostIndex)
                    {
                        isBestDNA = true;
                    }
                    else if (leftMostIndexSoFar == leftMostIndex)
                    {
                        if (currentSum > biggestSum)
                        {
                            isBestDNA = true;
                        }
                    }

                }
                if (isBestDNA == true)
                {
                    longestSequence = longestSequenceSoFar;
                    bestDNA = currentDNA;
                    bestDNASequence = currentSequence;
                    biggestSum = currentSum;
                    leftMostIndex = leftMostIndexSoFar;
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestDNASequence} with sum: {biggestSum}.");
            Console.WriteLine(String.Join(" ", bestDNA));

        }
    }
}

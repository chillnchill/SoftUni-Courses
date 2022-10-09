using System;
using System.Linq;

namespace T07_Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int longestSequence = 0;
            int currentLongestSequence = 0;
            int currentLongestNumber = 0;
            int longestSequenceNumber = 0;

            //inital spinny spinny 
            for (int i = 0; i < array.Length; i++)
            {
                currentLongestSequence = 0;
                //second 'for' cycle that starts from 'i' and checks if the next number is the same or breaks;
                for (int j = i; j <= array.Length-1; j++)
                {
                    if (array[j] == array[i])
                    {
                        currentLongestSequence++;
                        currentLongestNumber = array[i];
                    }
                    else
                    {
                        break;
                    }
                    if (currentLongestSequence > longestSequence)
                    {
                        longestSequence = currentLongestSequence;
                        longestSequenceNumber = currentLongestNumber;
                    }
                    
                }
                
            }
            //create a new array with the length of the longest sequence of identical numbers
            //, each index will be the number of that sequence
            
            int[] finalSequence = new int[longestSequence];
             for (int i = 0; i < finalSequence.Length; i++)
            {
                finalSequence[i] = longestSequenceNumber;
                Console.Write($"{finalSequence[i]} ");
            }

            
            
            

        }
    }
}

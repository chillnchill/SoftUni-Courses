using System;

namespace T04_Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleInJury = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            int presentationCount = 0;
            double finalGrade = 0;

            while (presentationName != "Finish")
            {
                double presentationGrade = 0;
                for (int i = 1; i <= peopleInJury; i++)
                {
                    presentationGrade += double.Parse(Console.ReadLine());
                }
                presentationGrade /= peopleInJury;

                Console.WriteLine($"{presentationName} - {presentationGrade:f2}.");
                finalGrade += presentationGrade;
                presentationCount++;
                presentationName = Console.ReadLine();
            }
            finalGrade /= presentationCount;
            Console.WriteLine($"Student's final assessment is {finalGrade:f2}.");
        }
    }
}
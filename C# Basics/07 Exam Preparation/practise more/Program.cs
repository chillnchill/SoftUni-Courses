using System;

namespace practise_more
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfKozunaks = int.Parse(Console.ReadLine());
            int singleChefGrade = 0;
            int maxGrade = 0;
            int currentMaxGrade = 0;
            string winner = "";

            for (int i = 0; i < numberOfKozunaks; i++)
            {
                string kozunakMaker = Console.ReadLine();
                string grade = Console.ReadLine();

                while (grade != "Stop")
                {
                    singleChefGrade += int.Parse(grade);

                    if (singleChefGrade > maxGrade)
                    {
                        
                        maxGrade = singleChefGrade;
                    }

                    grade = Console.ReadLine();
                }

                if (grade == "Stop")
                {
                    Console.WriteLine($"{kozunakMaker} has {singleChefGrade} points.");
                    
                    if (singleChefGrade > currentMaxGrade)
                    {
                        Console.WriteLine($"{kozunakMaker} is the new number 1!");
                        currentMaxGrade = singleChefGrade;
                        winner = kozunakMaker;
                    }
                    singleChefGrade = 0;
                }


            }
            Console.WriteLine($"{winner} won competition with {maxGrade} points!");

        }
    }
}

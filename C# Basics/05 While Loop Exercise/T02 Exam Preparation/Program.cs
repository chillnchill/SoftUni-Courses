using System;

namespace T02_Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());         
            double averageGrade = 0;
            int numberOfTasks = 0;
            int grade;
            int fail = 0;
            string lastTask = "";
          

            string taskName = Console.ReadLine();

            while (taskName != "Enough")
            {
                lastTask = taskName;
                grade = int.Parse(Console.ReadLine());
                averageGrade += grade;
                numberOfTasks++;

                if (grade <= 4)
                {
                    fail++;
                }
                if (fail == badGrades)
                {
                    Console.WriteLine($"You need a break, {fail} poor grades.");
                    break;
                }
                taskName = Console.ReadLine();
            }


            if (taskName == "Enough")
            {
                Console.WriteLine($"Average score: {averageGrade / numberOfTasks:f2}");
                Console.WriteLine($"Number of problems: {numberOfTasks}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
        }
    }
}

using System;

namespace T08_Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            double currentClass = 1;
            double gradeSum = 0;
            double fail = 0;
           



            while (currentClass <= 12)
            {
                if (grade < 4.00)
                {
                    fail++;
                }
                if (fail == 2)
                {
                    currentClass--;
                    Console.WriteLine($"{studentName} has been excluded at {currentClass} grade");
                    break;
                }


                gradeSum += grade;
                double average = gradeSum / currentClass;
                currentClass++;


                if (currentClass > 12)
                {
                    Console.WriteLine($"{studentName} graduated. Average grade: {average:f2}");
                    break;
                }
                grade = double.Parse(Console.ReadLine());

            }




        }
    }
}

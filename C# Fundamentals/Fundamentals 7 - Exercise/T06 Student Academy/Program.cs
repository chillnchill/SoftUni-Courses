using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentGrades = new Dictionary<string, List<double>>();
            
            for (int i = 0; i < rotations; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades.Add(studentName, new List<double>());                   
                }
                studentGrades[studentName].Add(grade);

            }


            foreach (var pair in studentGrades)
            {
                string student = pair.Key;
                var grade = pair.Value;

                if (grade.Average() >= 4.50)
                {
                    Console.WriteLine($"{student} -> {grade.Average():f2}");
                } 
            }
        }
    }
}

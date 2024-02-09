using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < input; i++)
            {
                string[] students = Console.ReadLine().Split(' ');
                string name = students[0];
                decimal grade = decimal.Parse(students[1]); 

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                    studentGrades[name].Add(grade);
                }
                else
                {
                    studentGrades[name].Add(grade);
                }
            }

            foreach (var name in studentGrades)
            {                
                Console.WriteLine($"{name.Key} -> {string.Join(" ", name.Value.Select(x => ($"{x:f2}")))} (avg: {name.Value.Average():f2})");
            }
           
            
        }
    }
}

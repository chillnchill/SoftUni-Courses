using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" : ");
            Dictionary<string, List<string>> classStudent = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string course = input[0];
                string student = input[1];

                if (!classStudent.ContainsKey(course))
                {
                    classStudent.Add(course, new List<string>());                   
                    classStudent[course].Add(student);
                }
                else if (classStudent.ContainsKey(course))
                {
                    classStudent[course].Add(student);
                }

                input = Console.ReadLine().Split(" : ");
            }

            foreach (var pair in classStudent)
            {
                string course = pair.Key;
                var student = pair.Value;

                Console.WriteLine($"{course}: {student.Count}");

                foreach (var item in student)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
            
            

        
        }
    }
}

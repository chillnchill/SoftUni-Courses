using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Students
{
     class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());

            List<Student> studentList = new List<Student>();

            for (int i = 0; i < studentCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ");

                var individualStudent = new Student(studentInfo[0], studentInfo[1], double.Parse(studentInfo[2]));

                studentList.Add(individualStudent);

                studentList = studentList.OrderByDescending(currStudent => currStudent.Grade).ToList();

            }
            studentList.ForEach(student => Console.WriteLine(student));

        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}";
    }
}

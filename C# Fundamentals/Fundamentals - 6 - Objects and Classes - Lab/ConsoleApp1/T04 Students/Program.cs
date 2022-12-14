using System;
using System.Collections.Generic;

namespace T04_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string[] studentInformation = Console.ReadLine().Split(' ');

            while (studentInformation[0] != "end")
            {
                Student student = new Student
                {
                    FirstName = studentInformation[0],
                    LastName = studentInformation[1],
                    Age = int.Parse(studentInformation[2]),
                    HomeTown = studentInformation[3]
                };

                students.Add(student);

                studentInformation = Console.ReadLine().Split(' ');
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}

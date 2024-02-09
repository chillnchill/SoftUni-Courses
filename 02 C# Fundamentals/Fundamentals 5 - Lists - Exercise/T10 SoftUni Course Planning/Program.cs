using System;
using System.Collections.Generic;
using System.Linq;

namespace T10_SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> course = Console.ReadLine().Split(", ").ToList();
            List<string> commands = Console.ReadLine().Split(":").ToList();

            while (commands[0] != "course start")
            {
                bool isLessonThere = course.Contains(commands[1]);
                bool isExerciseThere = course.Contains($"{commands[1]}-Exercise");
                int lessonIndex = 0;

                switch (commands[0])
                {
                    case "Add":
                        if (isLessonThere == false)
                        {
                            course.Add(commands[1]);
                        }
                        break;
                    case "Insert":
                        if (int.Parse(commands[2]) >= 0 && int.Parse(commands[2]) < course.Count && !isLessonThere)
                        {
                            course.Insert(int.Parse(commands[2]), commands[1]);
                        }
                        break;
                    case "Remove":
                        if (isLessonThere)
                        {
                            course.Remove(commands[1]);
                        }
                        if (isExerciseThere)
                        {
                            course.Remove($"{commands[1]}-Exercise");
                        }
                        break;
                    case "Swap":

                        SwapExistingLessons(course, commands[1], commands[2], isExerciseThere);
                        break;
                    case "Exercise":

                        if (isLessonThere == false)
                        {
                            course.Add(commands[1]);
                            course.Add($"{commands[1]}-Exercise");
                        }
                        if (isLessonThere && isExerciseThere)
                        {
                            break;
                        }
                        else if (isLessonThere && isExerciseThere == false)
                        {
                            lessonIndex = course.IndexOf(commands[1]);
                            course.Insert(lessonIndex + 1, $"{commands[1]}-Exercise");
                        }

                        break;
                }
                commands = Console.ReadLine().Split(":").ToList();
            }
            for (int i = 0; i < course.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{course[i]}");
            }

        }

        private static void SwapExistingLessons(List<string> course, string v1, string v2, bool isExerciseThere)
        {
            bool lessonOne = course.Contains(v1);
            bool lessonTwo = course.Contains(v2);
            bool isSecondExThere = course.Contains($"{v2}-Exercise");

            if (lessonOne && lessonTwo)
            {
                //find first lesson position
                int one = course.IndexOf(v1);
                //find second lesson position
                int two = course.IndexOf(v2);
                //swap them
                course[one] = v2;
                course[two] = v1;

                if (isExerciseThere)
                {
                    course.Remove($"{v1}-Exercise");
                    course.Insert(two + 1, ($"{v1}-Exercise"));
                }
                if (isSecondExThere)
                {
                    course.Remove($"{v2}-Exercise");
                    course.Insert(one + 1, ($"{v2}-Exercise"));
                }
            }
        }
    }
}

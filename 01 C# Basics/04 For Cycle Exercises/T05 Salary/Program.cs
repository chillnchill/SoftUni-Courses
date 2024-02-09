using System;

namespace T05_Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double fine = 0;
            string site = string.Empty;

            for (int i = 0; i <= tabs; i++)
            {
                 site = Console.ReadLine();

                 if (site == "Facebook")
                {
                    fine += 150;
                }   

                else if (site == "Instagram")
                {
                    fine += 100;
                }

                else if (site == "Reddit")
                {
                    fine += 50;
                }

                if (fine >= salary)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }

            }


            
            if (salary > fine)
                Console.WriteLine(salary - fine);
            
        }
    }
}

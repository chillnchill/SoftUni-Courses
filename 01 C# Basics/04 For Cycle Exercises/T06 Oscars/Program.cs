using System;

namespace T06_Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int evaluators = int.Parse(Console.ReadLine());

            double length = 0;
            double totalPoints = 0 + academyPoints;

            for (int i = 0; i < evaluators; i++)
            {
                string evaluatorName = Console.ReadLine();
                double evaluatorPoints = double.Parse(Console.ReadLine());

                length = evaluatorName.Length;
                totalPoints += (length * evaluatorPoints) / 2;

                if (totalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:f1}!");
                    break;
                }



            }
            if (totalPoints <= 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - totalPoints:f1} more!");
            }



        }
    }
}

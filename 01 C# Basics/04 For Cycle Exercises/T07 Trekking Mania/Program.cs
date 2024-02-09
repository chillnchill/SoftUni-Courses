using System;

namespace T07_Trekking_Mania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            double Musala = 0;
            double Montblanc = 0;
            double Kilimanjaro = 0;
            double K2 = 0;
            double Everest = 0;
            double total = 0;

            for (int i = 0; i < numberOfGroups; i++)
            {
                int numberOfClimbers = int.Parse(Console.ReadLine());


                if (numberOfClimbers <= 5)
                {
                    Musala += numberOfClimbers;
                }
                else if (numberOfClimbers >= 6 && numberOfClimbers <= 12)
                {
                    Montblanc += numberOfClimbers;
                }
                else if (numberOfClimbers >= 13 && numberOfClimbers <= 25)
                {
                    Kilimanjaro += numberOfClimbers;
                }
                else if (numberOfClimbers >= 26 && numberOfClimbers <= 40)
                {
                    K2 += numberOfClimbers;
                }
                else if (numberOfClimbers > 40)
                {
                    Everest += numberOfClimbers;
                }
                total += numberOfClimbers;
            }

            Musala = Musala / total * 100;
            Montblanc = Montblanc / total * 100;
            Kilimanjaro = Kilimanjaro / total * 100;
            K2 = K2 / total * 100;
            Everest = Everest / total * 100;

            Console.WriteLine($"{Musala:f2}%");
            Console.WriteLine($"{Montblanc:f2}%");
            Console.WriteLine($"{Kilimanjaro:f2}%");
            Console.WriteLine($"{K2:f2}%");
            Console.WriteLine($"{Everest:f2}%");
            
        }
    }
}

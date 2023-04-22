using System;

namespace T06_Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double standardTickets = 0;
            double studentTickets = 0;
            double kidTickets = 0;


            while (input != "Finish")
            {

                double roomCapacity = int.Parse(Console.ReadLine());
                double ticketsPerMovie = 0;
                string ticketType = Console.ReadLine();

                while (ticketType != "End")
                {

                    if (ticketType == "standard")
                    {
                        ticketsPerMovie++;
                        standardTickets++;
                    }
                    else if (ticketType == "student")
                    {
                        ticketsPerMovie++;
                        studentTickets++;
                    }
                    else
                    {
                        ticketsPerMovie++;
                        kidTickets++;
                    }
                    if (roomCapacity == ticketsPerMovie)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();

                }
                double roomCapacityPercent = (ticketsPerMovie * 100) / roomCapacity;
                Console.WriteLine($"{input} - {roomCapacityPercent:f2}% full.");
                input = Console.ReadLine();
            }
            double totalTickets = standardTickets + studentTickets + kidTickets;
            double studentTicketPercent = (studentTickets * 100) / totalTickets;
            double standardTicketPercent = (standardTickets * 100) / totalTickets;
            double kidTicketPercent = (kidTickets * 100) / totalTickets;

            Console.WriteLine($"{totalTickets}");
            Console.WriteLine($"{studentTicketPercent:f2}% student tickets.");
            Console.WriteLine($"{standardTicketPercent:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketPercent:f2}% kids tickets.");
        }
    }
}

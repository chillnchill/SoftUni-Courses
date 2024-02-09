using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1Vehicles.Models;
using T2VehiclesExtension.Models;

namespace T1Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


                switch (command[0])
                {
                    case "Drive":
                        {
                            try
                            {
                                if (command[1] == "Car")
                                {
                                    Console.WriteLine(car.Drive(double.Parse(command[2])));
                                }
                                else if (command[1] == "Truck")
                                {
                                    Console.WriteLine(truck.Drive(double.Parse(command[2])));
                                }
                                else
                                {
                                    Console.WriteLine(bus.Drive(double.Parse(command[2])));
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "Refuel":
                        {
                            try
                            {
                                if (command[1] == "Car")
                                {
                                    car.Refuel(double.Parse(command[2]));
                                }
                                else if (command[1] == "Truck")
                                {
                                    truck.Refuel(double.Parse(command[2]));
                                }
                                else
                                {
                                    bus.Refuel(double.Parse(command[2]));
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "DriveEmpty":
                        {
                            try
                            {
                                bus.DriveEmpty(double.Parse(command[2]));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                }

            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}

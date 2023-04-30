using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilots;
        private IRepository<IRace> races;
        private IRepository<IFormulaOneCar> cars;
        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilots.FindByName(pilotName);
            IFormulaOneCar car = cars.FindByName(carModel);

            if (pilot == null || pilot.CanRace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            cars.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = races.FindByName(raceName);
            IPilot pilot = pilots.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = cars.FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilots.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilot = new Pilot(fullName);
            pilots.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = races.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            races.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (IPilot pilot in pilots.Models.OrderByDescending(n => n.NumberOfWins))
            {
                result.AppendLine(pilot.ToString());
            }
            return result.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (IRace race in races.Models.Where(r => r.TookPlace == true)) 
            {
                result.AppendLine(race.RaceInfo());
            }
            return result.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName);
            

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist");
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }


           
            List<IPilot> orderedPilots = race.Pilots.OrderByDescending(n => n.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            race.TookPlace = true;
            orderedPilots[0].WinRace();
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Pilot {orderedPilots[0].FullName} wins the {raceName} race.");
            result.AppendLine($"Pilot {orderedPilots[1].FullName} is second in the {raceName} race.");
            result.AppendLine($"Pilot {orderedPilots[2].FullName} is third in the {raceName} race.");

            return result.ToString().TrimEnd();

        }
    }
}

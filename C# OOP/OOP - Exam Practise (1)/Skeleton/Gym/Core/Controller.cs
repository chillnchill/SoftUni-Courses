using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private readonly ICollection<Gym.Models.Gyms.Gym> gyms;

        public Controller()
        {
            gyms = new List<Gym.Models.Gyms.Gym>();
            equipmentRepository = new EquipmentRepository();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);
            Athlete athelete;
            bool gymIsCorrect = false;

            if (athleteType == "Boxer")
            {
                athelete = new Boxer(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name == "BoxingGym")
                {
                    gymIsCorrect = true;
                    gym.AddAthlete(athelete);
                }
            }
            else if (athleteType == "Weightlifter")
            {
                athelete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name == "WeightliftingGym")
                {
                    gymIsCorrect = true;
                    gym.AddAthlete(athelete);
                }
            } 
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

                        
            if (gymIsCorrect)
            {
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
            
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "Kettlebell")
            {
                equipmentRepository.Add(new Kettlebell());
            }
            else if (equipmentType == "BoxingGloves")
            {
                equipmentRepository.Add(new BoxingGloves());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(gn => gn.Name == gymName);
            double weight = gym.EquipmentWeight;
            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = equipmentRepository.FindByType(equipmentType);

            if (equipment != null)
            {
                var gym = gyms.FirstOrDefault(gn => gn.Name == gymName);
                gym.AddEquipment(equipment);
                equipmentRepository.Remove(equipment);
                return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
            }


            throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(gn => gn.Name == gymName);
            gym.Exercise();
            int numOfAthletes = gym.Athletes.Count;
            return String.Format(OutputMessages.AthleteExercise, numOfAthletes);
        }
    }
}

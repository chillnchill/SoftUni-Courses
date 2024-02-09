using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get { return Equipment.Select(eq => eq.Weight).Sum(); }
        }

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {

            if (Athletes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();
            string atheletesNames;
            if (Athletes.Count > 0)
            {
                atheletesNames = string.Join(", ", (Athletes.Select(n => n.FullName)));
            }
            else
            {
                atheletesNames = "No athletes";
            }

            result.AppendLine($"{Name} is a {GetType().Name}:");
            result.AppendLine($"Athletes: {atheletesNames}");
            result.AppendLine($"Equipment total count: {Equipment.Count}");
            result.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}

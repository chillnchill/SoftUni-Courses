using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private readonly List<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            this.BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;

        public void Eating(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                this.BatteryLevel += this.ConvertionCapacityIndex;

                if (this.BatteryLevel == this.BatteryCapacity)
                {
                    break;
                }
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string standards = "none";
            if (interfaceStandards.Count > 0)
            {
                standards = string.Join(", ", interfaceStandards);
            }
            result.AppendLine($"{this.GetType().Name} {this.Model}:");
            result.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            result.AppendLine($"--Current battery level: {this.BatteryLevel}");
            result.AppendLine($"--Supplements installed: {standards}");

            return result.ToString().TrimEnd();

        }
    }
}

using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISupplement> supplements;
        private readonly IRepository<IRobot> robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);

        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> availableRobots = new List<IRobot>();
            foreach (IRobot robot in robots.Models())
            {
                if (robot.InterfaceStandards.Contains(intefaceStandard))
                {
                    availableRobots.Add(robot);
                }
            }
            if (availableRobots.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int sum = availableRobots.Sum(x => x.BatteryLevel);

            if (sum < totalPowerNeeded)
            {
                int needed = totalPowerNeeded - sum;
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, needed);
            }

            int counterOfRobotsParticipating = 0;
            bool isFinished = false;

            foreach (IRobot worker in availableRobots.OrderByDescending(x => x.BatteryLevel))
            {
                if (worker.BatteryLevel >= totalPowerNeeded)
                {
                    worker.ExecuteService(totalPowerNeeded);
                    counterOfRobotsParticipating++;
                    isFinished = true;
                    break;
                }
                else
                {
                    totalPowerNeeded -= worker.BatteryLevel;
                    worker.ExecuteService(worker.BatteryLevel);
                    counterOfRobotsParticipating++;
                }
                if (isFinished)
                {
                    break;
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counterOfRobotsParticipating);
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (IRobot robot in robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity))
            {
                result.AppendLine(robot.ToString());
            }
            return result.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> energyStarvedBots = robots.Models().Where(x => x.Model == model).ToList();
            int fedRobots = 0;
            foreach (IRobot robot in energyStarvedBots)
            {
                if (robot.BatteryLevel < robot.BatteryCapacity / 2)
                {
                    robot.Eating(minutes);
                    fedRobots++;
                }
            }
            return string.Format(OutputMessages.RobotsFed, fedRobots);

        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;
            List<IRobot> availableRobots = new List<IRobot>();

            foreach (IRobot robot in robots.Models())
            {
                if (!robot.InterfaceStandards.Contains(interfaceValue) && robot.Model == model)
                {
                    availableRobots.Add(robot);
                }
            }

            if (availableRobots.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            availableRobots[0].InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }
    }
}

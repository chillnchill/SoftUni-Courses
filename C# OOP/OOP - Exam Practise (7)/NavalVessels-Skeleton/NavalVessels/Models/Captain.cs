using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private const int combatExperienceGain = 10;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
            this.CombatExperience = 0;
        }

        public string FullName
        {
            get => fullName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessels == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience() => this.CombatExperience += combatExperienceGain;

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            
            if (vessels.Count > 0)
            {
                foreach (IVessel vessel in vessels)
                {
                    result.AppendLine(vessel.ToString());
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}

using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private List<string> targets;

        protected Vessel(string name, double armorThickness, double mainWeaponCaliber, double speed)
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        //initialize
        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string tgs = "None";
            result.AppendLine($"- {Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Armor thickness: {ArmorThickness}");
            result.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            result.AppendLine($" *Speed: {Speed} knots");

            if (targets.Count > 0)
            {
                tgs = string.Join(", ", targets);
            }

            result.AppendLine($" *Targets: {tgs}");
            return result.ToString().TrimEnd();
          
        }
    }
}

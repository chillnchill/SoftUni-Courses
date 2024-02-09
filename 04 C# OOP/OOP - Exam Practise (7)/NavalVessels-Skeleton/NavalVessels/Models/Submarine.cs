using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, 200, mainWeaponCaliber, speed)
        {
        }

        public bool SubmergeMode {get; private set;} = false;

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string isSonarOn = SubmergeMode ? "ON" : "OFF";
            result.AppendLine(base.ToString());
            result.AppendLine($" *Submerge mode: {isSonarOn}");
            return result.ToString().TrimEnd();
        }
    }
}

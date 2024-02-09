using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, 300, mainWeaponCaliber, speed)
        {
        }

        public bool SonarMode { get; private set; } = false;

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string isSonarOn = SonarMode ? "ON" : "OFF";
            result.AppendLine(base.ToString());
            result.AppendLine($" *Sonar mode: {isSonarOn}");
            return result.ToString().TrimEnd();
        }
    }
}

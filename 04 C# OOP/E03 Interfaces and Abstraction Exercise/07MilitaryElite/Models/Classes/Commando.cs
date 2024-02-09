using _07MilitaryElite.Enums;
using _07MilitaryElite.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _07MilitaryElite.Models.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                result.AppendLine($"  {mission.ToString()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}

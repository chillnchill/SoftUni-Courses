using _07MilitaryElite.Enums;
using _07MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07MilitaryElite.Models.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepairs> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepairs> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}

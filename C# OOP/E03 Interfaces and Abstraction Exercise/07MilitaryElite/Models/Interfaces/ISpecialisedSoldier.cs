using _07MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07MilitaryElite.Models.Interfaces
{
    public interface ISpecialisedSoldier : ISoldier
    {
        Corps Corps { get; }
    }
}

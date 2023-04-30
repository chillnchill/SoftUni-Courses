using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07MilitaryElite.Models.Interfaces
{
    public interface IRepairs
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}

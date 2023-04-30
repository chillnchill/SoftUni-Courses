using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power) : base(name, 80)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}

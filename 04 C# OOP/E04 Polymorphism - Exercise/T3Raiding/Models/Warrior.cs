using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, 100)
        {
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}

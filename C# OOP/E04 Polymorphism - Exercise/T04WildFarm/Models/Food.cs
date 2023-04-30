using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }

    }
}

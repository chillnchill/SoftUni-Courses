using System;
using System.Collections.Generic;
using System.Text;

namespace Dice
{
    public class Dice
    {
        public int Side { get; set; }
        public string Color { get; set; }
        
    }
    public void ThrowDice()
    {
        Random random = new Random();
        int side = random.Next(1, 7);

        Dice dice = new Dice()
        {
            Side = side,
            Color = "Pink"
        };
        return dice;
    }


}

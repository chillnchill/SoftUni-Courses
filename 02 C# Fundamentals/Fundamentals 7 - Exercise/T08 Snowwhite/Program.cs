using System;
using System.Collections.Generic;
using System.Linq;


namespace T08_Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dwarfInput = Console.ReadLine().Split(" <:> ");

            Dictionary<string, int> dwarfNamePhysics = new Dictionary<string, int>();

            while (dwarfInput[0] != "Once upon a time")
            {
                string name = dwarfInput[0];
                string color = dwarfInput[1];
                int physics = int.Parse(dwarfInput[2]);
                string dwarfID = $"{name}:{color}";

                if (!dwarfNamePhysics.ContainsKey(dwarfID))
                {
                    dwarfNamePhysics.Add(dwarfID, physics);                    
                }
                else
                {
                    dwarfNamePhysics[dwarfID] = Math.Max(dwarfNamePhysics[dwarfID], physics);
                }


                dwarfInput = Console.ReadLine().Split(" <:> ");
            }



            foreach (var dwarf in dwarfNamePhysics
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfNamePhysics.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                                             .Count()))
            {
                Console.WriteLine("({0}) {1} <-> {2}",
                    dwarf.Key.Split(':')[1],
                    dwarf.Key.Split(':')[0],
                    dwarf.Value);
            }




        }
    }
}

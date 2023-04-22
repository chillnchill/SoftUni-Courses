using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count { get { return multiprocessor.Count; } }

        public void Add(CPU cpu)
        { 
            if (multiprocessor.Count < Capacity)
            {
                multiprocessor.Add(cpu);
                return;
            }
        }

        public bool Remove(string brand)
        {
            CPU cpuToRemove = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpuToRemove != null)
            {
                return Multiprocessor.Remove(cpuToRemove);
            }

            return false;
        }

        public CPU MostPowerful()
        {
            if (multiprocessor.Count == 0)
            {
                return null;
            }
             CPU mostBiggles = multiprocessor.OrderByDescending(f => f.Frequency)
                .FirstOrDefault();
                return mostBiggles;
        }

        public CPU GetCPU(string brand)
        {
            CPU thisCPU = multiprocessor.FirstOrDefault(b => b.Brand == brand);
            return thisCPU;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var process in multiprocessor)
            {
                result.AppendLine(process.ToString());
            }
            return result.ToString().Trim();
        }
    }
}

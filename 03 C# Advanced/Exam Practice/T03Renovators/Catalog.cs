using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T03Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;
        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int neededRenovators;
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }

        private string project;
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        public int Count { get { return renovators.Count; } }

        public string AddRenovator(Renovator renovator)
        {
            if (String.IsNullOrEmpty(renovator.Name) || String.IsNullOrEmpty(renovator.Type))
            {
                return $"Invalid renovator's information.";
            }
            if (NeededRenovators <= renovators.Count)
            {
                return $"Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(renovators => renovators.Name == name);

            return renovators.Remove(renovator);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> leftRenovators = renovators.Where(r => r.Type != type).ToList();
            int removedCount = Count - leftRenovators.Count;
            renovators = leftRenovators;
            return removedCount;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(renovators => renovators.Name == name);

            if (renovator != null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }
        
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payRenovator = renovators.Where(r => r.Days >= days).ToList();
            return renovators = payRenovator;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"Renovators available for Project {this.Project}:");

            List<Renovator> unhired = renovators.Where(r => r.Hired == false).ToList();

            foreach (var renovator in unhired)
            {
                result.Append(renovator);
            }
            
            return result.ToString().Trim(); 
        }
    }
}

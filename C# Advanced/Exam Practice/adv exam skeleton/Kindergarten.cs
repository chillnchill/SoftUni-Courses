using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }
        
        public bool RemoveChild(string childFullName)
        {
            string[] name = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = name[0];
            string lastName = name[1];

            Child child = Registry.Where(n => n.FirstName == firstName && n.LastName == lastName).FirstOrDefault();

            if (Registry.Contains(child))
            {
                Registry.Remove(child);
                return true;
            }
            return false;
        }

        public int ChildrenCount { get {return this.Registry.Count; } }

        public Child GetChild(string childFullName)
        {
            string[] name = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = name[0];
            string lastName = name[1];

            Child child = Registry.Where(n => n.FirstName == firstName && n.LastName == lastName).FirstOrDefault();
            return child;
        }

        public string RegistryReport()
        {
            StringBuilder result = new StringBuilder();
            List<Child> children = Registry.OrderByDescending(a => a.Age).ThenBy(ln => ln.LastName).ThenBy(fn => fn.FirstName).ToList();

            result.AppendLine($"Registered children in {Name}:");

            foreach (Child child in children)
            {
                result.AppendLine(child.ToString());
            }

            return result.ToString().TrimEnd();   

        }
    }
}

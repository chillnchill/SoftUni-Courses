using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;
        private string[] allowedCategories = new string[] { "Technical", "Economical", "Humanity" };

        public University(int id, string name, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = id;    
            Name = name;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects.ToList();
        }


        public int Id { get; private set; }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Category
        {
            get => category;
            private set
            {
                if (!allowedCategories.Contains(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (capacity < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }

        }

        private List<int> requiredSubjects;
        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects.AsReadOnly();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> students;

        public StudentRepository()
        {
            students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => students;

        public void AddModel(IStudent model)
        {
            Student student = new Student(students.Count + 1, model.FirstName, model.LastName);
            students.Add(student);
        }

        public IStudent FindById(int id) => students.FirstOrDefault(x => x.Id == id);

        public IStudent FindByName(string name) => students.FirstOrDefault(x => x.FirstName + " " + x.LastName == name);
    }
}

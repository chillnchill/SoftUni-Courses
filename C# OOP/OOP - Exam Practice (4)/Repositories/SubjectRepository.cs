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
    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly List<ISubject> subjects;

        public SubjectRepository()
        {
            subjects = new List<ISubject>();
        }
        public IReadOnlyCollection<ISubject> Models => subjects;

        public void AddModel(ISubject model)
        {
            ISubject subject = null;

            if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(subjects.Count + 1, model.Name);
            }
            if (model is HumanitySubject)
            {
                subject = new HumanitySubject(subjects.Count + 1, model.Name);
            }
            if (model is TechnicalSubject)
            {
                subject = new TechnicalSubject(subjects.Count + 1, model.Name);
            }

            subjects.Add(subject);

        }

        public ISubject FindById(int id) => subjects.FirstOrDefault(x => x.Id == id);

        public ISubject FindByName(string name) => subjects.FirstOrDefault(x => x.Name == name);

    }
}

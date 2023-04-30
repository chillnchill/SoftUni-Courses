using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        
        public RaceRepository()
        {
            races = new List<IRace>();
        }
        private List<IRace> races;
        public IReadOnlyCollection<IRace> Models => this.races.AsReadOnly();

        public void Add(IRace model) => races.Add(model);

        public IRace FindByName(string name) => races.FirstOrDefault(n => n.RaceName == name);

        public bool Remove(IRace model) => races.Remove(model);
    }
}

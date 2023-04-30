using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
       
        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        private List<IPilot> pilots;
        public IReadOnlyCollection<IPilot> Models => this.pilots.AsReadOnly();

        public void Add(IPilot model) => pilots.Add(model);

        public IPilot FindByName(string name) => pilots.FirstOrDefault(n => n.FullName == name);


        public bool Remove(IPilot model) => pilots.Remove(model);
    }
}

using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        
        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }
        private List<IFormulaOneCar> cars;

        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars.AsReadOnly();

        public void Add(IFormulaOneCar model) => cars.Add(model);

        public IFormulaOneCar FindByName(string name) => cars.FirstOrDefault(n => n.Model == name);

        public bool Remove(IFormulaOneCar model) => cars.Remove(model);
    }
}

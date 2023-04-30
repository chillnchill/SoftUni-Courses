﻿using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunnies;
        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies;

        public void Add(IBunny model) => bunnies.Add(model);
       

        public IBunny FindByName(string name) => bunnies.FirstOrDefault(n => n.Name == name);
        public bool Remove(IBunny model) => bunnies.Remove(model);
    }
}

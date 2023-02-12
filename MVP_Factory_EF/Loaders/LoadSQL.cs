using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Loaders
{
    internal class LoadSQL : ILoader
    {
        private AnimalContext _db;

        public LoadSQL()
        {
            _db = new AnimalContext();
        }

        public List<Animal> Load()
        {
            _db.Animals.Load();
            return _db.Animals.ToList();
        }
    }
}

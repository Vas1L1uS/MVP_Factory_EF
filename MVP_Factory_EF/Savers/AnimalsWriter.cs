using MVP_Factory_EF.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Savers
{
    internal class AnimalsWriter
    {
        public AnimalsWriter(ISaver mode)
        {
            Mode = mode;
        }

        public ISaver Mode { get; set; }

        public void Save(List<Animal> animals)
        {
            Mode.Save(animals);
        }

        public void Save(List<Animal> animals, ISaver mode)
        {
            Mode = mode;
            Mode.Save(animals);
        }
    }
}

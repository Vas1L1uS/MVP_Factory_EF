using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Loaders
{
    internal class AnimalsReader
    {
        public AnimalsReader(ILoader mode)
        {
            Mode = mode;
        }

        public ILoader Mode { get; set; }

        public List<Animal> Load()
        {
            return Mode.Load();
        }

        public List<Animal> Load(ILoader mode)
        {
            Mode = mode;
            return Mode.Load();
        }
    }
}
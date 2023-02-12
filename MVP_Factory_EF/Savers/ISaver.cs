using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Savers
{
    internal interface ISaver
    {
        void Save(List<Animal> animalsList);
    }
}

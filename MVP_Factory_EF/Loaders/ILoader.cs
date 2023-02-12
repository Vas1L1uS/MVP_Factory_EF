using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Loaders
{
    internal interface ILoader
    {
        List<Animal> Load();
    }
}

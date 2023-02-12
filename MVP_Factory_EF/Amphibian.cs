using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    internal class Amphibian : Animal
    {
        public Amphibian()
        {
            base.Type = "Земноводное";
        }
        public Amphibian(string kind) : base(kind)
        {
            base.Type = "Земноводное";
        }
    }
}

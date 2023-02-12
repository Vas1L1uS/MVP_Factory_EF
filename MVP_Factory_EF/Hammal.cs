using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    internal class Hammal : Animal
    {
        public Hammal()
        {
            base.Type = "Млекопитающее";
        }
        public Hammal(string kind) : base(kind)
        {
            base.Type = "Млекопитающее";
        }
    }
}

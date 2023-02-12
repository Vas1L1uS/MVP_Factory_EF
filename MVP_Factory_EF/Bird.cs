using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    internal class Bird : Animal
    {
        public Bird()
        {
            base.Type = "Птица";
        }
        public Bird(string kind) : base(kind)
        {
            base.Type = "Птица";
        }
    }
}

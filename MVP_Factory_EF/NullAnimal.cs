using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    internal class NullAnimal : Animal
    {
        public NullAnimal()
        {
            base.Kind = "Нет вида";
            base.Type = "Нет типа";
        }
        public NullAnimal(string kind = "Нет вида") : base(kind)
        {
            base.Type = "Нет типа";
        }
    }
}

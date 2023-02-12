using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    public abstract class Animal
    {
        public Animal() { }

        public Animal(string kind)
        {
            if (kind == default(string))
            {
                Kind = "Нет типа";
            }
            else
            {
                Kind = kind;
            }
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Kind { get; set; }
    }
}

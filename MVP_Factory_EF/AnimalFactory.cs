using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    static public class AnimalFactory
    {
        static public Animal GetAnimal(string type, string kind)
        {
            switch (type)
            {
                case "Млекопитающее":
                    return new Hammal(kind);
                case "Птица":
                    return new Bird(kind);
                case "Земноводное":
                    return new Amphibian(kind);
                case "Амфибия":
                    return new Amphibian(kind);
                default:
                    return new NullAnimal(kind);
            }
        }
    }
}

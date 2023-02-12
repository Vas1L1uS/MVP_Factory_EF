using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVP_Factory_EF.Savers
{
    internal class SaveToXML : ISaver
    {
        public void Save(List<Animal> animalsList)
        {
            XElement animals = new XElement("Животные");

            for (int i = 0; i < animalsList.Count; i++)
            {
                XElement animal = new XElement("Animal");
                XAttribute xAttributeType = new XAttribute("type", animalsList[i].Type);
                XAttribute xAttributeKind = new XAttribute("kind", animalsList[i].Kind);

                animal.Add(xAttributeType);
                animal.Add(xAttributeKind);

                animals.Add(animal);
            }

            animals.Save("animals.xml");
        }
    }
}

using MVP_Factory_EF.Savers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace MVP_Factory_EF.Loaders
{
    internal class LoadXML : ILoader
    {
        public List<Animal> Load()
        {
            string xml;
            var animals = new List<Animal>();
            try
            {
                xml = System.IO.File.ReadAllText("animals.xml");

                List<XElement> listAnimalsXElement = XDocument.Parse(xml).Descendants("Animal").ToList();

                foreach (var item in listAnimalsXElement)
                {
                    string Type = item.Attribute("type").Value;
                    string Kind = item.Attribute("kind").Value;
                    
                    Animal animal = AnimalFactory.GetAnimal(Type, Kind);
                    animals.Add(animal);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не существует. Будет создан новый файл.");
                SaveToXML saveToXML = new SaveToXML();
                saveToXML.Save(animals);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return animals;
        }
    }
}

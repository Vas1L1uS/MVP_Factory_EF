using MVP_Factory_EF.Savers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVP_Factory_EF.Loaders
{
    internal class LoadJSON : ILoader
    {
        public List<Animal> Load()
        {
            string json;
            var animals = new List<Animal>();

            try
            {
                json = File.ReadAllText("animals.json");

                JToken[] jArrayAnimals = JObject.Parse(json)["Animals"].ToArray();

                foreach (var item in jArrayAnimals)
                {
                    string Type = item["type"].ToObject<string>();
                    string Kind = item["kind"].ToObject<string>();

                    Animal animal = AnimalFactory.GetAnimal(Type, Kind);

                    animals.Add(animal);
                }
            }
            catch
            {
                Console.WriteLine("Файл не существует. Будет создан новый файл.");
                SaveToJSON saveToJSON = new SaveToJSON();
                saveToJSON.Save(animals);
            }
            return animals;
        }
    }
}

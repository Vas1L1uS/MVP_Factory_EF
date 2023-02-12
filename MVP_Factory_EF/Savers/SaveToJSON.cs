using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVP_Factory_EF.Savers
{
    internal class SaveToJSON : ISaver
    {
        public void Save(List<Animal> animalsList)
        {
            try
            {
                JObject mainTree = new JObject();
                JArray animalsArray = new JArray();

                for (int i = 0; i < animalsList.Count; i++)
                {
                    JObject animal = new JObject();
                    animal["type"] = animalsList[i].Type;
                    animal["kind"] = animalsList[i].Kind;

                    animalsArray.Add(animal);
                }

                mainTree["Animals"] = animalsArray;

                string json = JsonConvert.SerializeObject(mainTree);
                File.WriteAllText("animals.json", json);
                Console.WriteLine("Файл успешно сохранен.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не удалось сохранить из-за ошибки:");
                Console.WriteLine(e.Message);
            }
        }
    }
}

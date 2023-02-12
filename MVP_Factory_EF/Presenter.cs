using MVP_Factory_EF.Loaders;
using MVP_Factory_EF.Savers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF
{
    internal class Presenter
    {
        public Presenter()
        {
            Db = new AnimalContext();
            AnimalsLocal = new List<Animal>();

            Reader = new AnimalsReader(Load_SQL);
            Writer = new AnimalsWriter(Save_SQL);

            Load_SQL = new LoadSQL();
            Save_SQL = new SaveToSQL();

            Load_XML = new LoadXML();
            Save_XML = new SaveToXML();

            Load_JSON = new LoadJSON();
            Save_JSON = new SaveToJSON();
        }
        public AnimalContext Db { get; private set; }
        private AnimalsReader Reader { get; set; }
        private AnimalsWriter Writer { get; set; }

        public List<Animal> AnimalsLocal;

        public LoadSQL Load_SQL;
        public SaveToSQL Save_SQL;

        public LoadXML Load_XML;
        public SaveToXML Save_XML;

        public LoadJSON Load_JSON;
        public SaveToJSON Save_JSON;

        public void Load(ILoader mode)
        {
            AnimalsLocal.Clear();
            AnimalsLocal = Reader.Load(mode);
        }

        public void Save(ISaver mode)
        {
            Writer.Save(AnimalsLocal, mode);

            ILoader loadMode;

            if (mode == Save_XML)
            {
                loadMode = Load_XML;
            }
            else if (mode == Save_JSON)
            {
                loadMode = Load_JSON;
            }
            else
            {
                loadMode = Load_SQL;
            }
            AnimalsLocal = Reader.Load(loadMode);
        }

        public void AddAnimal(string type, string kind)
        {
            Animal animal = AnimalFactory.GetAnimal(type, kind);
            AnimalsLocal.Add(animal);
        }

        public void EditAnimal(Animal selectedAnimal, string type, string kind)
        {
            for (int i = 0; i < AnimalsLocal.Count; i++)
            {
                if (AnimalsLocal[i].Equals(selectedAnimal))
                {
                    AnimalsLocal[i].Type = type;
                    AnimalsLocal[i].Kind = kind;
                    return;
                }
            }
        }

        public void DeleteAnimal(Animal selectedAnimal)
        {
             AnimalsLocal.Remove(selectedAnimal);
        }
    }
}

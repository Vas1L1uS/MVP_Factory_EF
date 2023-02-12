using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_Factory_EF.Savers
{
    internal class SaveToSQL : ISaver
    {
        private AnimalContext _db;

        public SaveToSQL()
        {
            _db = new AnimalContext();
        }

        public void Save(List<Animal> animalsLocal)
        {
            _db.Animals.Load();
            DbSet<Animal> animalsDatabase = _db.Animals;

            for (int i = 0; i < animalsDatabase.Local.Count; i++)
            {
                for (int k = 0; k < animalsLocal.Count; k++)
                {
                    if (animalsLocal[k].Id == animalsDatabase.Local[i].Id)
                    {
                        if (animalsLocal[k].Type == animalsDatabase.Local[i].Type && animalsLocal[k].Kind == animalsDatabase.Local[i].Kind)
                        {
                            break;
                        }
                        else
                        {
                            var a = animalsDatabase.Find(animalsDatabase.Local[i].Id);
                            a.Type = animalsLocal[k].Type;
                            a.Kind = animalsLocal[k].Kind;
                            _db.Entry(a).State = EntityState.Modified;
                            break;
                        }
                    }
                    else if (animalsLocal[k].Id == default(int) || k == animalsLocal.Count - 1)
                    {
                        _db.Animals.Remove(animalsDatabase.Local[i]);
                        break;
                    }
                }                
            }
            animalsLocal.Reverse();

            for (int i = 0; i < animalsLocal.Count; i++)
            {
                if (animalsLocal[i].Id == default(int))
                {
                    _db.Animals.Add(animalsLocal[i]);
                }
                else
                {
                    break;
                }
            }

            _db.SaveChanges();
            animalsLocal = _db.Animals.ToList();
        }
    }
}

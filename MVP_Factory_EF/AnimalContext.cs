using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVP_Factory_EF
{
    public class AnimalContext : DbContext
    {
        public AnimalContext() : base("DbConnection") { }
        public DbSet<Animal> Animals { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using bo;

namespace dal
{
    class Context : DbContext
    {
        public Context() : base("name=ParkitectString")
        {

        }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<EvenementImage> EvenementImages { get; set; }
    }
}

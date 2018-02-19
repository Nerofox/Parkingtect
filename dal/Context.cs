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
        public Context() : base("name=DefaultConnection")
        {

        }

        public DbSet<Evenement> Events { get; set; }
        public DbSet<EvenementImage> EventsImages { get; set; }
    }
}

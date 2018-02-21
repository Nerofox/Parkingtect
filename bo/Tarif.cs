using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo
{
    class Tarif
    {
        public double price { get; set; }

        public DateTime horaire { get; set; }

        public int duration { get; set; } // event duration in minutes

        public Tarif()
        {
            
        }
    }
}

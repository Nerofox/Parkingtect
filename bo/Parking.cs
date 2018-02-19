using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bo
{
    public class Parking
    {
        public string Id { get; set; }

        public string Nom { get; set; }

        public string Status { get; set; }

        public int PlaceTotale { get; set; }

        public int PlaceLibre { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Parking()
        {

        }
    }
}

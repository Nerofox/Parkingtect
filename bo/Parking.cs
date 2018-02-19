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

        public string Name { get; set; }

        public string Status { get; set; }

        public int MaxPlace { get; set; }

        public int FreePlace { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public dynamic Geometry { get; set; }

        public Parking()
        {

        }
    }
}

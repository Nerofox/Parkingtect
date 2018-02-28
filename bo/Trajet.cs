using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo
{
    public class Trajet
    {

        public dynamic Parking { get; set; }

        public dynamic DrivingDirection { get; set; }

        public dynamic WalkingDirection { get; set; }

        public int Duration { get; set; }

        public int Distance { get; set; }


        public Trajet(dynamic parking)
        {
            this.Parking = parking;
        }
    }
}

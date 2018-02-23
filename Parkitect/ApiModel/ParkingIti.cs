using bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkitect.ApiModel
{
    public class ParkingIti : Parking
    {
        public double Dist { get; set; }
        public double TimeSecund { get; set; }

        public dynamic GeometryIti { get; set; }
    }
}
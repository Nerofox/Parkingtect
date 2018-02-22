using bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parkitect.ApiModel
{
    public class ParkingIti : Parking
    {
        public int Dist { get; set; }
        public int TimeSecund { get; set; }
    }
}
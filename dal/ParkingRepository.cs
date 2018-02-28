using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bo;

namespace dal
{
    public class ParkingRepository : BasicRepository<Parking>
    {
        public override void Update(Parking obj)
        {
     
            base.Update(obj);
        }
    }
}

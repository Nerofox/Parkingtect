using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bo;

namespace dal
{
    public class HoraireParkingRepository : BasicRepository<HoraireParking>
    {
        public override void Update(HoraireParking obj)
        {
     
            base.Update(obj);
        }
    }
}

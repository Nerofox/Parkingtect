using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bo;

namespace dal
{
    public class EvenementRepository : BasicRepository<Evenement>
    {
        public override void Update(Evenement obj)
        {
     
            base.Update(obj);
        }
    }
}

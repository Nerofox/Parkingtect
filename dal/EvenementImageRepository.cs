using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bo;

namespace dal
{
    public class EvenementImageRepository : BasicRepository<EvenementImage>
    {
        public List<EvenementImage> FindAllByEvenement(int evtId)
        {
            return this.dbSet.Where(img => img.Evenement.Id == evtId).ToList();
        }
    }
}

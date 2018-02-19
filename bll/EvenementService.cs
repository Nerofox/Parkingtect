using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using bo;

namespace bll
{
    public class EvenementService
    {
        private EvenementRepository eventRepository;

        public EvenementService()
        {
            this.eventRepository = new EvenementRepository();
        }

        public List<Evenement> FindAll()
        {
            return this.eventRepository.FindAll();
        }
    }
}

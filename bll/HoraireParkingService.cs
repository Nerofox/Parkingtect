using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using bo;

namespace bll
{
    public class HoraireParkingService
    {
        private HoraireParkingRepository horaireParkingRepository;

        public HoraireParkingService()
        {
            this.horaireParkingRepository = new HoraireParkingRepository();
        }

        public List<HoraireParking> FindAll()
        {
            return this.horaireParkingRepository.FindAll();
        }

        public HoraireParking Find(int id)
        {
            return this.horaireParkingRepository.Find(id);
        }

        public void Update(HoraireParking horaireParking)
        {
            this.horaireParkingRepository.Update(horaireParking);
        }

        public void Create(HoraireParking horaireParking)
        {
            this.horaireParkingRepository.Create(horaireParking);
        }

        public void Remove(HoraireParking horaireParking)
        {
            this.horaireParkingRepository.Remove(horaireParking);
        }
    }
}

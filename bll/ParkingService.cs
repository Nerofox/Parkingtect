using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;
using bo;

namespace bll
{
    public class ParkingService
    {
        private ParkingRepository parkingRepository;

        public ParkingService()
        {
            this.parkingRepository = new ParkingRepository();
        }

        public List<Parking> FindAll()
        {
            return this.parkingRepository.FindAll();
        }

        public Parking Find(int id)
        {
            return this.parkingRepository.Find(id);
        }

        public void Update(Parking parking)
        {
            this.parkingRepository.Update(parking);
        }

        public void Create(Parking parking)
        {
            this.parkingRepository.Create(parking);
        }

        public void Remove(Parking parking)
        {
            this.parkingRepository.Remove(parking);
        }
    }
}

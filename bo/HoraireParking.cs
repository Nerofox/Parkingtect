using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bo
{
    public class HoraireParking
    {
        public string Id { get; set; }

        public string Parking { get; set; }

        public int Jours { get; set; }

        public DateTime CloseTime { get; set; }

        public DateTime OpenTime { get; set; }
        public Parking()
        {

        }

        public Boolean isParkingOpen(DateTime currentTime, DateTime CloseTime, DateTime OpenTime)
        {
            bool isOpen = true;

            if (currentTime > CloseTime && currentTime < OpenTime)
            {
                isOpen = false;
            }

            return isOpen;
        }
    }
}

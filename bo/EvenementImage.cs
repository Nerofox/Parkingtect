using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bo
{
    public class EvenementImage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public virtual Evenement Evenement { get; set; }

        public EvenementImage()
        {

        }
    }
}

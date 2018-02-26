using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bo
{

        public enum TypeJour
        {
            Dimanche = 0,
            Lundi = 1,
            Mardi = 2,
            Mercredi = 3,
            Jeudi = 4,
            Vendredi = 5,
            Samedi = 6,
            Permanent = 7
        }

        public static class EnumExtension
        {
            public static int GetValue(this TypeJour nb)
            {
                return (int)nb;
            }
        }
    }
}

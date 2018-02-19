﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bo
{
    public class Evenement
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Theme { get; set; }

        public DateTime Date { get; set; }

        public List<EvenementImage> Images { get; set; }

        public Evenement()
        {

        }
    }
}

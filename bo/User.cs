using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bo
{
    public class User
    {
        public int Id { get; set; }

        public string Pseudo { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public User()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Address
    {
        public int id { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public int posta { get; set; }
        public int userFK { get; set; }
        public AppUser AppUser { get; set; }

    }
}

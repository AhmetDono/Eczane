using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Menu
    {
        [Key]
        public int id { get; set; }
        public string roleFK { get; set; } //duzenlenecek
        public DateTime created_at { get; set; }
    }
}

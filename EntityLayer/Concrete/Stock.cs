using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stock
    {
        [Key]
        public int id { get; set; }
        public int DrugFK { get; set; }
        public Drug Drug { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public DateTime created_at { get; set; }

    }
}

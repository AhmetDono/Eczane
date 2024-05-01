using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Drug
    {
        [Key]
        public int NDC { get; set; }
        public string drugName { get; set; }
        public string drugType { get; set; }
        public string drugImg { get; set; }
        public string dosage { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int supplierFK { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime created_at { get; set; }
    }
}

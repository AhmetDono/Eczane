using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TransactionDetail
    {
        [Key]
        public int id { get; set; }
        public int transactionFK { get; set; }
        public Transaction Transaction { get; set; }
        public string drugFK { get; set; }
        public Drug Drug { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public DateTime created_at { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Transaction
    {
        [Key]
        public int id { get; set; }

        public int userFK { get; set; }
        public AppUser AppUser { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }


        public double totalPrice { get; set; } 
        public DateTime created_at { get; set; }

        // Relationship
        public ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}

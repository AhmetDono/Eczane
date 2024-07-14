using EntityLayer.Concrete;

namespace E_czane.Areas.User.Models
{
    public class EditAddressViewModel
    {
        public int id { get; set; }
        public int UserFK { get; set; }
        public string FullName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}

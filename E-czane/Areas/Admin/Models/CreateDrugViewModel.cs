using EntityLayer.Concrete;

namespace E_czane.Areas.Admin.Models
{
    public class CreateDrugViewModel
    {
        public Drug Drug { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }
        public IFormFile DrugImage { get; set; }
    }
}

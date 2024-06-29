namespace E_czane.Areas.Admin.Models
{
    public class EditDrugViewModel
    {
        public int drugID { get; set; }
        public  string drugName { get; set; }
        public  string drugType { get; set; }
        public  int supplierID { get; set; }
        public  string dosage { get; set; }
        public  string description { get; set; }
        public double price { get; set; }
        public IFormFile DrugImage { get; set; }
        public string CurrentImagePath { get; set; }
    }
}

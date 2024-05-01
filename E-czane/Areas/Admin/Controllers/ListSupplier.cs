using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ListSupplier : Controller
    {
        SupplierManager supplierManager = new SupplierManager(new EfSupplierDal());
        public IActionResult Index()
        {
            var values = supplierManager.TGetList();
            return View(values);
        }
    }
}

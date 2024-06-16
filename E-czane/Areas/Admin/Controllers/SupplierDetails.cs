using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupplierDetails : Controller
    {
        SupplierManager supplierManager = new SupplierManager(new EfSupplierDal());
        public IActionResult Index(int id)
        {
            var value = supplierManager.TGetByID(id);
            return View(value);
        }
    }
}

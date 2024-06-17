using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ListSupplier : Controller
    {
        SupplierManager _supplierManager = new SupplierManager(new EfSupplierDal());

        //Supplier List
        public IActionResult Index()
        {
            var values = _supplierManager.TGetList();
            return View(values);
        }

        //Create Supplier
        [HttpGet]
        public IActionResult CreateSupplier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSupplier(Supplier supplier)
        {
           _supplierManager.Tadd(supplier);
            return RedirectToAction("Index","ListSupplier");
        }
    }
}

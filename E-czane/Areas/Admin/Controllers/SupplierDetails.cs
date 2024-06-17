using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupplierDetails : Controller
    {
        SupplierManager _supplierManager = new SupplierManager(new EfSupplierDal());


        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = _supplierManager.TGetByID(id);
            SupplierEditViewModel supplierEditViewModel = new SupplierEditViewModel()
            {
                supplierID = value.id,
                supplierName = value.name,
                phoneNumber = value.phoneNumber,
                email = value.email

            };
            return View(supplierEditViewModel);
        }

        //Update
        [HttpPost]
        public IActionResult UpdateSupplier(SupplierEditViewModel supplierEditViewModel)
        {
            var value = _supplierManager.TGetByID(supplierEditViewModel.supplierID);

            if (value == null)
            {
                //Veriler bos ise bos birakilamaz mesjai donmeli
                TempData["AlertMessage"] = "Supplier not found!";
                return RedirectToAction("Index", "SupplierDetails");
            }
            else
            {
                value.name = supplierEditViewModel.supplierName;
                value.phoneNumber = supplierEditViewModel.phoneNumber;
                value.email = supplierEditViewModel.email;

                _supplierManager.TUpdate(value);
                return RedirectToAction("Index", "ListSupplier");
            }
    
        }

        //Delete
        public IActionResult DeleteSupplier(int id)
        {
            var value = _supplierManager.TGetByID(id);
            _supplierManager.TDelete(value);
            return RedirectToAction("Index", "ListSupplier");
        }

    }
}

using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ListDrug : Controller
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        SupplierManager _supplierManager = new SupplierManager(new EfSupplierDal());

        //GET
        [HttpGet]
        public IActionResult Index()
        {
            
            var values = _drugManager.TGetList();
            return View(values);
        }

        //Create
        [HttpGet]
        public IActionResult CreateDrug()
        {
            var suppliers = _supplierManager.TGetList();
            var viewModel = new CreateDrugViewModel
            {
                Drug = new Drug(),
                Suppliers = suppliers
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrug(CreateDrugViewModel model)
        {
            if (model.DrugImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.DrugImage.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/images/drugImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await model.DrugImage.CopyToAsync(stream);
                model.Drug.drugImg = imagename;
            }
            _drugManager.Tadd(model.Drug);
            return RedirectToAction("Index","ListDrug");
        }
    }
}

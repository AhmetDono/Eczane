using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DrugDetails : Controller
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = _drugManager.TGetByID(id);
            EditDrugViewModel editDrugViewModel = new EditDrugViewModel()
            {
                drugID= value.NDC,
                drugName = value.drugName,
                drugType = value.drugType,
                supplierID = value.supplierFK,
                dosage = value.dosage,
                description = value.description,
                price = value.price,
                CurrentImagePath = value.drugImg,
            };
            return View(editDrugViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrug(EditDrugViewModel editDrugViewModel)
        {
            var value = _drugManager.TGetByID(editDrugViewModel.drugID);
                value.drugName = editDrugViewModel.drugName;
                value.drugType = editDrugViewModel.drugType;
                value.dosage = editDrugViewModel.dosage;
                value.description = editDrugViewModel.description;
                value.price = editDrugViewModel.price;
                if (editDrugViewModel.DrugImage != null)
                {
                    //eski footyu sil eger bos degilse
                    if (!string.IsNullOrEmpty(value.drugImg))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/drugImages", value.drugImg);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                        //eski foto bossa yine asagi aticak yeni footyu alacak

                        var resource = Directory.GetCurrentDirectory();
                        var extension = Path.GetExtension(editDrugViewModel.DrugImage.FileName);
                        var imagename = Guid.NewGuid() + extension;
                        var savelocation = resource + "/wwwroot/images/drugImages/" + imagename;
                        var stream = new FileStream(savelocation, FileMode.Create);
                        await editDrugViewModel.DrugImage.CopyToAsync(stream);
                        value.drugImg = imagename;
                    }
                    //bos ise hata dondur ama bossa zaten sayfa calismaz
                }
            _drugManager.TUpdate(value);
            return RedirectToAction("Index", "ListDrug");

        }

        public IActionResult Delete(int id)
        {
            var value = _drugManager.TGetByID(id);
            _drugManager.TDelete(value);
            return RedirectToAction("Index", "ListDrug", new { area = "Admin" });
        }

    }
}

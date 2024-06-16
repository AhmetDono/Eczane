using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DrugDetails : Controller
    {
        DrugManager drugManager = new DrugManager(new EfDrugDal());

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = drugManager.TGetByID(id);
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var value = drugManager.TGetByID(id);
            drugManager.TDelete(value);
            return RedirectToAction("Index", "ListDrug", new { area = "Admin" });
        }

        //duzenlenecek foto vs ayarlanacak
        public IActionResult Update(int id)
        {
            return View();
        }
    }
}

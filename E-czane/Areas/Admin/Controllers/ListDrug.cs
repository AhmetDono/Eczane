using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ListDrug : Controller
    {
        DrugManager drugManager = new DrugManager(new EfDrugDal());
        public IActionResult Index()
        {
            var values = drugManager.TGetList();
            return View(values);
        }
    }
}

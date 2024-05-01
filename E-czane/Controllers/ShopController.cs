using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class ShopController : Controller
    {
        DrugManager drugManager = new DrugManager(new EfDrugDal());
        public IActionResult Index()
        {
            var values = drugManager.TGetList();
            return View(values);
        }
    }
}

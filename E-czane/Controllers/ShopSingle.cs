using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace E_czane.Controllers
{
    public class ShopSingle : Controller
    {
        DrugManager drugManager = new DrugManager(new EfDrugDal());
        public IActionResult Index(int id)
        {
            var value = drugManager.TGetByID(id);
            return View(value);
        }
    }
}

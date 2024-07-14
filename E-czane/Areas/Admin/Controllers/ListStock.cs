using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ListStock : Controller
    {
        StockManager _stockManager = new StockManager(new EfStockDal());
        public IActionResult Index()
        {
            var values = _stockManager.TGetList();
            return View(values);
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ListStock : Controller
    {
        StockManager stockManager = new StockManager(new EfStockDal());
        public IActionResult Index()
        {
            var values = stockManager.TGetList();
            return View(values);
        }
    }
}

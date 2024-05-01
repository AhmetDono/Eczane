using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

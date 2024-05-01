using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

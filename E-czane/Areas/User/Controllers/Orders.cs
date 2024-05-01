using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.User.Controllers
{
    [Area("User")]
    public class Orders : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

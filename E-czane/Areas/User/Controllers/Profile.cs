using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.User.Controllers
{
    [Area("User")]
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

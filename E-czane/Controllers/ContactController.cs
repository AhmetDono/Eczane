using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

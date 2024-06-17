using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

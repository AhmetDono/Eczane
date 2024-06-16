using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ListTransaction : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

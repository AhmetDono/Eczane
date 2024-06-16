using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ListUser : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ListUser(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_userManager != null)
            {
                var values = _userManager.Users.ToList();
                return View(values);
            }
            else
            {
                return View();
            }
        }
    }
}

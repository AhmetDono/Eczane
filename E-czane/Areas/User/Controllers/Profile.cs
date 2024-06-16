using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Migrations;
using E_czane.Areas.User.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_czane.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class Profile : Controller
    {
        /*ppUserManager userManager = new AppUserManager(new EfAppUserDal());*/
        private readonly UserManager<AppUser> _userManager;

        public Profile(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var values = await _userManager.FindByEmailAsync(userEmailClaim.Value);

            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Phonenumber = values.PhoneNumber;
            userEditViewModel.Email = values.Email;
            userEditViewModel.Name = values.name;
            return View(userEditViewModel);
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Migrations;
using E_czane.Areas.Admin.Models;
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
        private readonly SignInManager<AppUser> _signInManager;

        public Profile(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        //Get
        [HttpGet]
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

        //Update
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserEditViewModel userEditViewModel)
        {
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var values = await _userManager.FindByEmailAsync(userEmailClaim.Value);
            values.PhoneNumber = userEditViewModel.Phonenumber;
            values.name = userEditViewModel.Name;
            //values.Email = userEditViewModel.Email;

            if (!string.IsNullOrEmpty(userEditViewModel.Password) && !string.IsNullOrEmpty(userEditViewModel.confirmPassword)) { 
                if (userEditViewModel.Password == userEditViewModel.confirmPassword)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(values);
                    var result = await _userManager.ResetPasswordAsync(values, token, userEditViewModel.Password);
                    if (!result.Succeeded)
                    {
                        // Sifre degistirme basarisiz oldu
                    }
                }
                else
                {
                    // Password eslesmiyor
                }
            }
            var updateResult = await _userManager.UpdateAsync(values);
                if (!updateResult.Succeeded)
                {
                    // Return the view with errors
                }

            //Logout yapmasi lazim logine atmali
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth", new { area = "" });
        }
    }
}

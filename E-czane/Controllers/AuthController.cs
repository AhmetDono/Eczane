using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_czane.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel modelLogin)
        {
            if (ModelState.IsValid) // Model geçerli mi kontrolü
            {
                if (!string.IsNullOrEmpty(modelLogin.Email)) // UserName null değilse devam et
                {
                    //emaile gore giris yapma gelicek
                    var  user = await _userManager.FindByEmailAsync(modelLogin.Email);
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, modelLogin.Password, false, false);
                    if (result.Succeeded)
                    {
                        // Oturum bilgilerini oluştur
                        var claims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name, modelLogin.UserName),
                    new Claim(ClaimTypes.Email,user.Email),
                    };

                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            // Oturumun süresi
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5), // 5 dakika
                            IsPersistent = true // Tarayıcı kapatılsa bile devam et
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            // Başarısız giriş veya geçersiz model durumunda Login sayfasına yönlendir
            return RedirectToAction("Login", "Auth");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel modelRegister)
        {
            AppUser appUser = new AppUser()
            {
                UserName = modelRegister.UserName,
                name = modelRegister.UserName,
                surname = modelRegister.UserName,
                Email = modelRegister.Email,
                imageUrl = "Default"
            };
            if (modelRegister.Password == modelRegister.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, modelRegister.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login","Auth");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(modelRegister);
        }


        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Remove("Cart");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_czane.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class ListAddress : Controller
    {
        AddressManager _addressManager = new AddressManager(new EfAddressDal());
        private readonly UserManager<AppUser> _userManager;

        public ListAddress(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var values = await _userManager.FindByEmailAsync(userEmailClaim.Value);
            var addresses = _addressManager.TGetListByFilter(a => a.UserFK == values.Id);
            return View(addresses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAddress()
        {
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var values = await _userManager.FindByEmailAsync(userEmailClaim.Value);
            var model = new Address
            {
                UserFK = values.Id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAddress(Address address)
        {
            _addressManager.Tadd(address);
            return RedirectToAction("Index","ListAddress");
        }
    }
}

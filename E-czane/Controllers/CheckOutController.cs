using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Helpers;
using E_czane.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_czane.Controllers
{
    public class CheckOutController : Controller
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        AddressManager _addressManager = new AddressManager(new EfAddressDal());
        private readonly UserManager<AppUser> _userManager;

        public CheckOutController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmailClaim.Value);

            var addresses = _addressManager.TGetListByFilter(a => a.UserFK == user.Id).ToList();


            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartItems = cart.Select(item => new CartItemViewModel
            {
                Drug = _drugManager.TGetByID(item.DrugId),
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList();

            var checkoutViewModel = new CheckoutViewModel
            {
                CartItems = cartItems,
                Addresses = addresses
            };


            return View(checkoutViewModel);
        }

        [HttpPost]
        public IActionResult Payment()
        {
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using E_czane.Models;
using E_czane.Helpers;
using EntityLayer.Concrete;

namespace E_czane.Controllers
{
    public class ShopSingle : Controller
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = _drugManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult AddToCart(int drugId, int quantity)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var drug = _drugManager.TGetByID(drugId);
            var cartItem = cart.FirstOrDefault(c => c.DrugId == drugId);

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    DrugId = drugId,
                    Price = drug.price,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index", "Cart");
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Helpers;
using E_czane.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Controllers
{
    public class Cart : Controller
    {
        DrugManager _drugManager = new DrugManager(new EfDrugDal());
        [HttpGet]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            var cartViewModel = cart.Select(item => new
            {
                Drug = _drugManager.TGetByID(item.DrugId),
                item.Quantity,
                Price = _drugManager.TGetByID(item.DrugId).price
            }).ToList();

            return View(cartViewModel);

        }

        //[HttpPost]
        //public IActionResult UpdateCartItem(int id, int quantity)
        //{
        //    var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        //    var cartItem = cart.FirstOrDefault(c => c.DrugId == id);
        //    if (cartItem != null)
        //    {
        //        if (quantity > 0)
        //        {
        //            cartItem.Quantity = quantity;
        //        }
        //        else
        //        {
        //            cart.Remove(cartItem);
        //        }
        //    }

        //    HttpContext.Session.SetObjectAsJson("Cart", cart);
        //    return RedirectToAction("Index", "Cart");
        //}

        public IActionResult DeleteCartItem(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var itemToRemove = cart.FirstOrDefault(c => c.DrugId == id);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index","Cart");
        }
    }
}

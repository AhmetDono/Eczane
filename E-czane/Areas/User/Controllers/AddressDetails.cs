using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using E_czane.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class AddressDetails : Controller
    {
        AddressManager _addressManager = new AddressManager(new EfAddressDal());

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = _addressManager.TGetByID(id);
            EditAddressViewModel editAddressViewModel = new EditAddressViewModel()
            {
                id = value.id,
                UserFK = value.UserFK,
                FullName = value.FullName,
                AddressLine1 = value.AddressLine1,
                AddressLine2 = value.AddressLine2,
                City = value.City,
                State = value.State,
                PostalCode = value.PostalCode,
                Country = value.Country,
                PhoneNumber = value.PhoneNumber,
            };
            return View(editAddressViewModel);
        }

        [HttpPost]
        public IActionResult UpdateAddress(EditAddressViewModel editAddressViewModel)
        {
            var value = _addressManager.TGetByID(editAddressViewModel.id);
            value.FullName = editAddressViewModel.FullName;
            value.AddressLine1 = editAddressViewModel.AddressLine1;
            value.AddressLine2 = editAddressViewModel.AddressLine2;
            value.City = editAddressViewModel.City;
            value.State = editAddressViewModel.State;
            value.PostalCode = editAddressViewModel.PostalCode;
            value.Country = editAddressViewModel.Country;
            value.PhoneNumber = editAddressViewModel.PhoneNumber;

            _addressManager.TUpdate(value);
            return RedirectToAction("Index","ListAddress");
        }

        public IActionResult DeleteAddress(int id)
        {
            var value = _addressManager.TGetByID(id);
            _addressManager.TDelete(value);
            return RedirectToAction("Index", "ListAddress");
        }
    }
}

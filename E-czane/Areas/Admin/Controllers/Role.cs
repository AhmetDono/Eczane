using E_czane.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Role : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public Role(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (_roleManager != null)
            {
                var values = _roleManager.Roles.ToList();
                // Proceed with using values
                return View(values);
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel p)
        {
            AppRole role = new AppRole()
            {
                Name = p.Name,
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Role");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index","Role");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                ID = value.Id,
                Name = value.Name,

            };
            return View(updateRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id ==updateRoleViewModel.ID);

            value.Name= updateRoleViewModel.Name;

            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index","Role");
        }
    }
}

using E_czane.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class Role : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public Role(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (_roleManager != null)
            {
                var values = _roleManager.Roles.ToList();
                return View(values);
            }
            else
            {
                return View();
            }

        }

        //CREATE

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }


        //DELETE

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


        //UPDATE

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


        //ASISIGN ROLE
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            if (_roleManager != null)
            {
                TempData["UserID"] = id;
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
                var roles = _roleManager.Roles.ToList();
                var userRoles = await _userManager.GetRolesAsync(user);
                List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
                foreach (var item in roles)
                {
                    RoleAssignViewModel model = new RoleAssignViewModel();
                    model.RoleID = item.Id;
                    model.RoleName = item.Name;
                    model.RoleExist = userRoles.Contains(item.Name);
                    roleAssignViewModels.Add(model);
                }
                return View(roleAssignViewModels);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int) TempData["userID"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index", "ListUser");
        }
    }
}

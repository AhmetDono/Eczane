﻿using Microsoft.AspNetCore.Mvc;

namespace E_czane.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

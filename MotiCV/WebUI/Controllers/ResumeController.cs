﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

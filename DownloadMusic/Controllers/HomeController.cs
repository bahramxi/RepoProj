﻿using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DownloadMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //   // return View("~/Areas/MainDownload/views/Home/index.cshtml");
        //   return View();
        //}

    }
}
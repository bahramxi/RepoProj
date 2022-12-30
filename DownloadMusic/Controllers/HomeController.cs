using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DownloadMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<TrackController> _logger;

        public HomeController(ILogger<TrackController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
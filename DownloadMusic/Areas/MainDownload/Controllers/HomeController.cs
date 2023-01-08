using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DownloadMusic.Areas.MainDownload.Controllers
{
    [Area("MainDownload")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Playlist()
        {
            return View();
        }
        public IActionResult Artist()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
using DownloadMusic.Areas.Admin.Controllers;
using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DownloadMusic.Areas.MainDownload.Controllers
{
    [Area("MainDownload")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public MusicDbContext _musicDbForMain;
        public HomeController(ILogger<HomeController> logger, MusicDbContext musicDb)
        {
            _logger = logger;
            _musicDbForMain = musicDb;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Category()
        {
                var resultList = _musicDbForMain.MusicTracks.ToList();
                var listViewModel = resultList.Select(
                    s => new DownloadMusicViewModel
                    {
                        Id = s.Id,
                        TitleMusic = s.TitleMusic,
                        Album = s.Album,
                        MusicCategory = s.MusicCategory,
                        Vocalist = s.Vocalist,
                        ImageFilePath = s.ImageFilePath,
                        MusicFilePath = s.MusicFilePath
                    }).OrderByDescending(x=>x.Id).ToList();
                return View(listViewModel);
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
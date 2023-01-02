using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.IO;

namespace DownloadMusic.Controllers
{
    public class TrackController : Controller
    {
        private readonly ILogger<TrackController> _logger;
        public MusicDbContext _musicDb { get; set; }
        public TrackController(ILogger<TrackController> logger, MusicDbContext musicDb)
        {
            _logger = logger;
            _musicDb = musicDb;
        }


        private byte[] FileConvertToByte(IFormFile file)
        {
            byte[] fileBytes = new byte[2];

            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();

                    // string s = Convert.ToBase64String(fileBytes);
                }
            }
            return fileBytes;

        }

        private bool AddMusic(MusicTrackViewModel model)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"UploadFile/{model.MusicCategory}");
            var musicFileName = model.MusicFile.FileName;
            var imageFileName = model.Image.FileName;
            FileInfo fileInfo = new FileInfo(model.MusicFile.FileName);
            string musicNameWithPath = Path.Combine(path, musicFileName);
            string imageWithPath = Path.Combine(path, imageFileName);
            var music = new MusicTrackModel()
            {
                Album = model.Album,
                TitleMusic = model.TitleMusic,
                Description = model.Description,
                ImageForSave = FileConvertToByte(model.Image),
                MusicForSave = FileConvertToByte(model.MusicFile),
                MusicText = model.MusicText,
                Songwriter = model.Songwriter,
                Vocalist = model.Vocalist,
                MusicCategory = model.MusicCategory,
                MusicFilePath = musicNameWithPath,
                MusicName = model.MusicFile.FileName,
                MusicFileExtention = fileInfo.Extension,
                ImageFilePath = imageWithPath
            };
            var result = _musicDb.Add(music);
            _musicDb.SaveChanges();
            return true;

        }
        public IActionResult GetList()
        {
            var resultList = _musicDb.MusicTracks.ToList();
            var listViewModel = resultList.Select(
                s => new MusicTrackViewModel
                {
                    //    {
                    Id=s.Id,
                    TitleMusic = s.TitleMusic,
                    Album = s.Album,
                    Description = s.Description,
                    MusicCategory = s.MusicCategory,
                    Songwriter = s.Songwriter,
                    Vocalist = s.Vocalist
                }).ToList();
            //foreach (var item in resultList)
            //{
            //    var viewModel = new MusicTrackViewModel
            //    {
            //        TitleMusic = item.TitleMusic,
            //        Album = item.Album,
            //        Description = item.Description,
            //        MusicCategory = item.MusicCategory,
            //        Songwriter = item.Songwriter,
            //        Vocalist = item.Vocalist

            //    };
            //    listViewModel.Add(viewModel);
            //}
            return View(listViewModel);
        }



        public IActionResult Add()
        {
            MusicTrackViewModel model = new MusicTrackViewModel();
            return View(model);
            // return View();
        }


        [HttpPost]
        public IActionResult Add(MusicTrackViewModel model)
        {
            model.IsResponse = true;
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"UploadFile/{model.MusicCategory}");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            var fileName = model.MusicFile.FileName;
            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                model.MusicFile.CopyTo(stream);
            }

            var result = AddMusic(model);
            model.IsSuccess = true;
            model.Message = "موزیک با موفقیت اضافه شد.";
            return View("Add", model);
        }


        public IActionResult Update(long? id)
         {

            if (id == null)
            {
                return NotFound();
            }
            var result = _musicDb.MusicTracks.Find(id);
            var updateMusic = new MusicTrackViewModel()
            {
                Id = id.Value,
                Album = result.Album,
                TitleMusic = result.TitleMusic,
                Description = result.Description,
                MusicText = result.MusicText,
                Songwriter = result.Songwriter,
                Vocalist = result.Vocalist
            };
            if (updateMusic==null)
            {
                return NotFound();
            }
            return View(updateMusic);
        }
            

    

    [HttpPost]
    public IActionResult Update(MusicTrackViewModel model,long id)
    {

            string path = Path.Combine(Directory.GetCurrentDirectory(), $"UploadFile/{model.MusicCategory}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var musicFileName = model.MusicFile.FileName;
            string fileNameWithPath = Path.Combine(path, musicFileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                model.MusicFile.CopyTo(stream);
            }
            var imageFileName = model.Image.FileName;
            FileInfo fileInfo = new FileInfo(model.MusicFile.FileName);
            string musicNameWithPath = Path.Combine(path, musicFileName);
            string imageWithPath = Path.Combine(path, imageFileName);
            

          var musicResult = _musicDb.MusicTracks.Find(id);

                musicResult.TitleMusic = model.TitleMusic;
                musicResult.Album = model.Album;
                musicResult.Description = model.Description;
                musicResult.Songwriter = model.Songwriter;
                musicResult.MusicCategory = model.MusicCategory;
                musicResult.Vocalist = model.Vocalist;
                musicResult.MusicText = model.MusicText;
                musicResult.MusicFilePath = musicNameWithPath;
                musicResult.ImageFilePath = imageWithPath;
                musicResult.MusicFileExtention = fileInfo.Extension;
                musicResult.MusicName = model.MusicFile.FileName;
                musicResult.MusicForSave = FileConvertToByte(model.MusicFile);
                musicResult.ImageForSave = FileConvertToByte(model.Image);

                _musicDb.Update(musicResult);
                _musicDb.SaveChanges();
                model.IsSuccess = true;
                model.IsResponse = true;
                model.Message = "موزیک با موفقیت ویرایش شد";

                //return RedirectToAction(nameof(Update));


        return View(model);
    }


    public IActionResult Remove(long id)
    {
        var result = _musicDb.MusicTracks.Find(id);
            if (result == null)
                return NotFound();
        var finlaResult = _musicDb.MusicTracks.Remove(result);
            _musicDb.SaveChanges();
            var IsMessage = "حذف با موفقیت انجام شد";
        return View("Remove",IsMessage);
    }

        public IActionResult Details(long id)
        {
            var result = _musicDb.MusicTracks.Find(id);
            var model = new MusicTrackViewModel
            {
                Id = id,
            TitleMusic = result.TitleMusic,
            Album = result.Album,
            Description = result.Description,
            Songwriter = result.Songwriter,
            MusicCategory = result.MusicCategory,
            Vocalist = result.Vocalist,
            MusicText = result.MusicText
        };
            return View(model);
        }


    }
}
﻿using DownloadMusic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.Diagnostics;

namespace DownloadMusic.Controllers
{
    public class TrackController : Controller
    {
        private readonly ILogger<TrackController> _logger;
        public  MusicDbContext _musicDb { get; set; }
        public TrackController(ILogger<TrackController> logger, MusicDbContext musicDb)
        {
            _logger = logger;
            _musicDb = musicDb;
        }


        private byte[] FileConvertToByte(IFormFile file)
        {
            byte[] fileBytes=new byte[2];

            if (file!=null && file.Length > 0)
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
                MusicCategory=model.MusicCategory,
                MusicFilePath="Null",
                ImageFilePath="Null"
            };
            var result=_musicDb.Add(music);
            _musicDb.SaveChanges();
            return true;

        }
        public IActionResult GetList()
        {
            var resultList = _musicDb.MusicTracks.ToList();
            var listViewModel =resultList.Select(
                s=>new MusicTrackViewModel { 
                            //    {
                    TitleMusic = s.TitleMusic,
                    Album = s.Album,
                    Description = s.Description,
                    MusicCategory = s.MusicCategory,
                    Songwriter = s.Songwriter,
                    Vocalist = s.Vocalist,

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
            //MusicTrackViewModel model = new MusicTrackViewModel();
            //return View(model);
            return View();
        }
        
        [HttpPost] 
        public IActionResult Add(MusicTrackViewModel model)
        {
          var result = AddMusic(model);
            return View("Add");
        }

        public IActionResult Update(MusicTrackModel model)
        {
            //var result = _musicDb.MusicTracks.Select(m=>m.Id == model.Id);
            //if (!result.IsNullOrEmpty())
            //{
            //    var updateMusic = new MusicTrackModel()
            //    {
            //        Album = model.Album,
            //        TitleMusic = model.TitleMusic,
            //        Description = model.Description,
            //        Image = model.Image,
            //        MusicFile = model.MusicFile,
            //        MusicText = model.MusicText,
            //        Songwriter = model.Songwriter,
            //        Vocalist = model.Vocalist
            //    };
            //}
            //return View(updateMusic);
            return Ok(ErrorEventArgs.Empty);
        }


        public IActionResult Remove(int id)
        {   var result= _musicDb.MusicTracks.Select(m=>m.Id ==id);
            var finlaResult = _musicDb.Remove(result);
            return View(result);
        }

       

    }
}
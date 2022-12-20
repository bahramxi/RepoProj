﻿using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DownloadMusic.Models
{
    public class MusicTrackViewModel
    {

        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "نام موزیک", Prompt = "نام موزیک"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string TitleMusic { get; set;}


        [Display(Name = "ترانه سرا", Prompt = "ترانه سرا"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Songwriter { get; set;}

        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "خواننده", Prompt = "خواننده"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Vocalist { get; set; }


        [Display(Name = "نام آلبوم", Prompt = "نام آلبوم"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Album { get; set; }


        [Display(Name = "متن آهنگ", Prompt = "متن آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string MusicText { get; set; }

        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "آپلود فایل آهنگ", Prompt = "آپلود فایل آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        [NotMapped]
        public IFormFile MusicFile { get; set; }


        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "کاور آهنگ", Prompt = "کاور آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        [NotMapped]
        public IFormFile Image { get; set; }



        [Display(Name = "توضیحات آهنگ", Prompt = "توضیحات آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Description { get; set; }
    }
}

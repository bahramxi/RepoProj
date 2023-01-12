using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DownloadMusic.Models
{
    public class DownloadMusicViewModel : ResponseModel
    {
        [HiddenInput]
        public long Id { get; set; }

        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "نام موزیک", Prompt = "نام موزیک"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string TitleMusic { get; set; }


        [Display(Name = "ترانه سرا", Prompt = "ترانه سرا"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Songwriter { get; set; }


        [Required(ErrorMessage = "{0} را وارد نمایید")]
        [Display(Name = "خواننده", Prompt = "خواننده"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Vocalist { get; set; }


        [Display(Name = "نام آلبوم", Prompt = "نام آلبوم"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Album { get; set; }


        [Display(Name = "دسته بندی آهنگ", Prompt = "دسته بندی آهنگ")]
        public MusicCategory MusicCategory { get; set; }


        [Display(Name = "متن آهنگ", Prompt = "متن آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string MusicText { get; set; }


        [Display(Name = "توضیحات آهنگ", Prompt = "توضیحات آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string Description { get; set; }


        [Display(Name = "متن آهنگ", Prompt = "متن آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string MusicFilePath { get; set; }


        [Display(Name = "متن آهنگ", Prompt = "متن آهنگ"), MaxLength(150, ErrorMessage = "حداکثر {0} باید {1} کاراکتر باشد")]
        public string ImageFilePath { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DownloadMusic.Models
{
    public class MusicTrackModel
    {
        public long Id { get; set; }


        public string TitleMusic { get; set;}


        public string Songwriter { get; set;}


        public string Vocalist { get; set; }

        public MusicCategory MusicCategory { get; set; }

        public string Album { get; set; }


        public string MusicText { get; set; }

        public string MusicFilePath { get; set; }
        public string MusicName { get; set; }
        public string MusicFileExtention { get; set; }
        public byte[] MusicForSave { get; set; }


        public string ImageFilePath { get; set; }
        public byte[] ImageForSave{ get; set; }


        public string Description { get; set; }
    }
}

namespace DownloadMusic.Models
{
    public class MusicTrackModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Songwriter { get; set; }
        public string Vocalist { get; set; }
        public string Album { get; set; }
        public string MusicText { get; set; }
        public IFormFile MusicFile { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}

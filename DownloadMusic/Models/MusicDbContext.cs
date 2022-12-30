using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace DownloadMusic.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            //modelBuilder.Entity<MusicTrackModel>().HasData(
            //    new MusicTrackModel { MusicFilePath="Null",ImageFilePath= "Null", MusicCategory = MusicCategory.Pop, Album = "PareParvaz", Description = "آهنگ فوق العاده زیبای پنجره", MusicText = "یه پنجره با یه قفس یه حنجره بی هم نفس", Songwriter = "روزبه بمانی", Vocalist = "Dariush", TitleMusic = "Panjere", ImageForSave = new byte[5], MusicForSave = new byte[9] },
            //    new MusicTrackModel {  MusicFilePath = "Null", ImageFilePath = "Null", MusicCategory = MusicCategory.Pop, Album = "PareParvaz", Description = "آهنگ فوق العاده زیبای یخ زدم", MusicText = "گیر کردم تو شبی که  گفتی باید جداشیم", Songwriter = "ایرج جنتی", Vocalist = "Shadmehr", TitleMusic = "PareParvaz", ImageForSave = new byte[5], MusicForSave = new byte[9] },
            //    new MusicTrackModel {  MusicFilePath = "Null", ImageFilePath = "Null", MusicCategory = MusicCategory.Classic, Album = "PareParvaz", Description = "آهنگ فوق العاده زیبای پرپرواز", MusicText = "تو هجوم مبهم  پنجره ها پر پرواز منو ازم نگیرید", Songwriter = "منصور تهرانی", Vocalist = "Ebi", TitleMusic = "Batel", ImageForSave = new byte[5], MusicForSave = new byte[9] },
            //    new MusicTrackModel {  MusicFilePath = "Null", ImageFilePath = "Null", MusicCategory = MusicCategory.Pop, Album = "HeseKhob", Description = " آهنگ فوق العاده زیبای باطل", MusicText = "باطل است باطل نباش عزیز من", Songwriter = "اردلان سرافراز", Vocalist = "Sattar", TitleMusic = "YakhZadam", ImageForSave = new byte[5], MusicForSave = new byte[9] },
            //    new MusicTrackModel {  MusicFilePath = "Null", ImageFilePath = "Null", MusicCategory = MusicCategory.Sonati, Album = "HeseKhob", Description = "آهنگ فوق العاده زیبای حس خوب", MusicText = "حس خوبیه وقتی یک نفر منتظرت باشه", Songwriter = "میلاد بابایی", Vocalist = "Omid", TitleMusic = "HesseKhob", ImageForSave = new byte[5], MusicForSave = new byte[9] }

            //    );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("MusicConnection");
            //optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<MusicTrackModel> MusicTracks { get; set; }
    }
}

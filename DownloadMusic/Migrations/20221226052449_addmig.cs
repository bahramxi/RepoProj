using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DownloadMusic.Migrations
{
    /// <inheritdoc />
    public partial class addmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 5L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MusicTracks",
                columns: new[] { "Id", "Album", "Description", "ImageFilePath", "ImageForSave", "MusicCategory", "MusicFilePath", "MusicForSave", "MusicText", "Songwriter", "TitleMusic", "Vocalist" },
                values: new object[,]
                {
                    { 1L, "PareParvaz", "آهنگ فوق العاده زیبای پنجره", "Null", new byte[] { 0, 0, 0, 0, 0 }, 0, "Null", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "یه پنجره با یه قفس یه حنجره بی هم نفس", "روزبه بمانی", "Panjere", "Dariush" },
                    { 2L, "PareParvaz", "آهنگ فوق العاده زیبای یخ زدم", "Null", new byte[] { 0, 0, 0, 0, 0 }, 0, "Null", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "گیر کردم تو شبی که  گفتی باید جداشیم", "ایرج جنتی", "PareParvaz", "Shadmehr" },
                    { 3L, "PareParvaz", "آهنگ فوق العاده زیبای پرپرواز", "Null", new byte[] { 0, 0, 0, 0, 0 }, 2, "Null", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "تو هجوم مبهم  پنجره ها پر پرواز منو ازم نگیرید", "منصور تهرانی", "Batel", "Ebi" },
                    { 4L, "HeseKhob", " آهنگ فوق العاده زیبای باطل", "Null", new byte[] { 0, 0, 0, 0, 0 }, 0, "Null", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "باطل است باطل نباش عزیز من", "اردلان سرافراز", "YakhZadam", "Sattar" },
                    { 5L, "HeseKhob", "آهنگ فوق العاده زیبای حس خوب", "Null", new byte[] { 0, 0, 0, 0, 0 }, 1, "Null", new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "حس خوبیه وقتی یک نفر منتظرت باشه", "میلاد بابایی", "HesseKhob", "Omid" }
                });
        }
    }
}

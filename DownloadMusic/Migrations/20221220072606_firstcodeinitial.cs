using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DownloadMusic.Migrations
{
    /// <inheritdoc />
    public partial class firstcodeinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MusicTracks",
                newName: "TitleMusic");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageForSave",
                table: "MusicTracks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "MusicForSave",
                table: "MusicTracks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "MusicTracks",
                columns: new[] { "Id", "Album", "Description", "ImageForSave", "MusicForSave", "MusicText", "Songwriter", "TitleMusic", "Vocalist" },
                values: new object[,]
                {
                    { 1L, "PareParvaz", "آهنگ فوق العاده زیبای پنجره", new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "یه پنجره با یه قفس یه حنجره بی هم نفس", "روزبه بمانی", "Panjere", "Dariush" },
                    { 2L, "PareParvaz", "آهنگ فوق العاده زیبای یخ زدم", new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "گیر کردم تو شبی که  گفتی باید جداشیم", "ایرج جنتی", "PareParvaz", "Shadmehr" },
                    { 3L, "PareParvaz", "آهنگ فوق العاده زیبای پرپرواز", new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "تو هجوم مبهم  پنجره ها پر پرواز منو ازم نگیرید", "منصور تهرانی", "Batel", "Ebi" },
                    { 4L, "HeseKhob", " آهنگ فوق العاده زیبای باطل", new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "باطل است باطل نباش عزیز من", "اردلان سرافراز", "YakhZadam", "Sattar" },
                    { 5L, "HeseKhob", "آهنگ فوق العاده زیبای حس خوب", new byte[] { 0, 0, 0, 0, 0 }, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, "حس خوبیه وقتی یک نفر منتظرت باشه", "میلاد بابایی", "HesseKhob", "Omid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageForSave",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "MusicForSave",
                table: "MusicTracks");

            migrationBuilder.RenameColumn(
                name: "TitleMusic",
                table: "MusicTracks",
                newName: "Name");
        }
    }
}

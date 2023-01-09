using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DownloadMusic.Migrations
{
    /// <inheritdoc />
    public partial class addproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFilePath",
                table: "MusicTracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MusicCategory",
                table: "MusicTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MusicFilePath",
                table: "MusicTracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ImageFilePath", "MusicCategory", "MusicFilePath" },
                values: new object[] { "Null", 0, "Null" });

            migrationBuilder.UpdateData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ImageFilePath", "MusicCategory", "MusicFilePath" },
                values: new object[] { "Null", 0, "Null" });

            migrationBuilder.UpdateData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ImageFilePath", "MusicCategory", "MusicFilePath" },
                values: new object[] { "Null", 2, "Null" });

            migrationBuilder.UpdateData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ImageFilePath", "MusicCategory", "MusicFilePath" },
                values: new object[] { "Null", 0, "Null" });

            migrationBuilder.UpdateData(
                table: "MusicTracks",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ImageFilePath", "MusicCategory", "MusicFilePath" },
                values: new object[] { "Null", 1, "Null" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFilePath",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "MusicCategory",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "MusicFilePath",
                table: "MusicTracks");
        }
    }
}

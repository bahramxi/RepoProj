using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DownloadMusic.Migrations
{
    /// <inheritdoc />
    public partial class addMusicFileInfoToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MusicFileExtention",
                table: "MusicTracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MusicName",
                table: "MusicTracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusicFileExtention",
                table: "MusicTracks");

            migrationBuilder.DropColumn(
                name: "MusicName",
                table: "MusicTracks");
        }
    }
}

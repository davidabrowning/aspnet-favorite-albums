using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETFavoriteAlbums.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Albums");
        }
    }
}

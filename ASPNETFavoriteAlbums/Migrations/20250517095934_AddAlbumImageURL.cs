using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETFavoriteAlbums.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlbumImageURL",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumImageURL",
                table: "Albums");
        }
    }
}

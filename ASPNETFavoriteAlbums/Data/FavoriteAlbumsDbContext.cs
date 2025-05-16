using ASPNETFavoriteAlbums.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETFavoriteAlbums.Data
{
    public class FavoriteAlbumsDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public FavoriteAlbumsDbContext(DbContextOptions<FavoriteAlbumsDbContext> options) : base(options) 
        { 
        }
    }
}

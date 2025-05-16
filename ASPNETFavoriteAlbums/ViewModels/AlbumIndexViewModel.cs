using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.ViewModels
{
    public class AlbumIndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; } = new List<Album>();
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}

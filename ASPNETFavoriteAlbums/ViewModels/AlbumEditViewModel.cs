using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.ViewModels
{
    public class AlbumEditViewModel
    {
        public Album Album { get; set; }
        public IEnumerable<Tag> AllTags { get; set; } = new List<Tag>();
        public IEnumerable<int> SelectedTagIds { get; set; } = new List<int>();
    }
}

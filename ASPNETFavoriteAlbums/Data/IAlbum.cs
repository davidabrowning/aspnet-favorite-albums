using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.Data
{
    public interface IAlbum
    {
        Album GetById(int id);
        IEnumerable<Album> GetAll();
        void Add(Album album);
        void Update(Album album);
        void Delete(int id);
    }
}

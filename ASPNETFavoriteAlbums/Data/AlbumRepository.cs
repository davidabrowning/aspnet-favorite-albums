using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.Data
{
    public class AlbumRepository : IAlbum
    {
        private FavoriteAlbumsDbContext _favoriteAlbumsDbContext;
        public AlbumRepository(FavoriteAlbumsDbContext favoriteAlbumsDbContext)
        {
            _favoriteAlbumsDbContext = favoriteAlbumsDbContext;
        }

        public void Add(Album album)
        {
            _favoriteAlbumsDbContext.Albums.Add(album);
            _favoriteAlbumsDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _favoriteAlbumsDbContext.Albums.Remove(GetById(id));
            _favoriteAlbumsDbContext.SaveChanges();
        }

        public IEnumerable<Album> GetAll()
        {
            return _favoriteAlbumsDbContext.Albums;
        }

        public Album GetById(int id)
        {
            return _favoriteAlbumsDbContext.Albums.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Update(Album album)
        {
            _favoriteAlbumsDbContext.Albums.Update(album);
            _favoriteAlbumsDbContext.SaveChanges();
        }
    }
}

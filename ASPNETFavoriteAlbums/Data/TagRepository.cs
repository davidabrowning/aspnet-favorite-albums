using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.Data
{
    public class TagRepository : ITag
    {
        FavoriteAlbumsDbContext _favoriteAlbumsDbContext;
        public TagRepository(FavoriteAlbumsDbContext favoriteAlbumsDbContext)
        {
            _favoriteAlbumsDbContext = favoriteAlbumsDbContext;
        }

        public void Add(Tag tag)
        {
            _favoriteAlbumsDbContext.Tags.Add(tag);
            _favoriteAlbumsDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _favoriteAlbumsDbContext.Tags.Remove(GetById(id));
            _favoriteAlbumsDbContext.SaveChanges();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _favoriteAlbumsDbContext.Tags.OrderBy(t => t.Name);
        }

        public Tag GetById(int id)
        {
            return _favoriteAlbumsDbContext.Tags.Where(t => t.Id == id).FirstOrDefault();
        }

        public void Update(Tag tag)
        {
            _favoriteAlbumsDbContext.Tags.Update(tag);
            _favoriteAlbumsDbContext.SaveChanges();
        }
    }
}

using ASPNETFavoriteAlbums.Models;

namespace ASPNETFavoriteAlbums.Data
{
    public interface ITag
    {
        Tag GetById(int id);
        IEnumerable<Tag> GetAll();
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(int id);
    }
}

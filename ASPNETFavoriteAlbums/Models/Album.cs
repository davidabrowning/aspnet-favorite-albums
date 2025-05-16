namespace ASPNETFavoriteAlbums.Models
{
    public class Album
    {
        public int Id { get; set; }
        public required string Name { get; set; } = "";
        public List<Tag> Tags { get; set; } = new();
    }
}

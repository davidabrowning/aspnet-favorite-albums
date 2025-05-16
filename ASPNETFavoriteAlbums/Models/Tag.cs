namespace ASPNETFavoriteAlbums.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Album> Albums { get; set; } = new();
    }
}

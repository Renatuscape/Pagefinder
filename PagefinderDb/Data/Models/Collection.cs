namespace PagefinderDb.Data.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Story>? Stories { get; set; }
    }
}

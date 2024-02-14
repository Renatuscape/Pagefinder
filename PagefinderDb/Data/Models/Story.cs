namespace PagefinderDb.Data.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public int CollectionId { get; set; }
        public Collection? Collection { get; set; }
        public ICollection<Page>? Pages { get; set; }
        public PlayTest? PlayTest { get; set; }
    }
}

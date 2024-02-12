namespace PagefinderDb.Data.Models
{
    public class PlayTest
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int Progress { get; set; }
        public Story? Story { get; set; }
        public ICollection<InventoryItem>? InventoryItems { get; set; }
    }
}

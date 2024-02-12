namespace PagefinderDb.Data.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public int PlayTestId { get; set; }
        public PlayTest? PlayTest { get; set; }
    }
}

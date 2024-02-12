namespace PagefinderDb.Data.Models
{
    public class ChoicePageNavigation
    {
        public int Id { get; set; } //Primary key
        public int ChoiceId { get; set; } //Foreign key to Choice
        public int PageId { get; set; } //Foreign key to Page
        public Choice? Choice { get; set; } //Choice nav prop
        public Page? Page { get; set; } //Page nav prop
    }
}

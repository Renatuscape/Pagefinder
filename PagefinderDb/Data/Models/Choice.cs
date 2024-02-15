namespace PagefinderDb.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public int SuccessPageId { get; set; } //The page it is on, foreign key
        public int FailurePageId { get; set; } //The page it leads to, foreign key
        public string? Text { get; set; } = string.Empty;

        public Page? SuccessPage { get; set; } //The page it is on, nav prop
        public Page? FailurePage { get; set; } //The page it leads to, nav prop

    }
}

namespace PagefinderDb.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int SuccessPageId { get; set; } //The page it is on, foreign key
        public int FailurePageId { get; set; } //The page it leads to, foreign key

        public Page? SuccessPage { get; set; } //The page it is on, nav prop
        public Page? FailurePage { get; set; } //The page it leads to, nav prop

        public ICollection<Requirement>? Requirements { get; set; } //Undirectional relation
        public ICollection<Restriction>? Restrictions { get; set; } //Undirectional relation
        public ICollection<Reward>? Rewards { get; set; } //Undirectional relation
    }
}

namespace PagefinderDb.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Character? SuccessSpeaker { get; set; }
        public string? SuccessText { get; set; } = string.Empty;

        public Character? FailureSpeaker { get; set; }
        public string? FailureText { get; set; } = string.Empty;

        public ChoicePageNavigation? ChoicePageNavigation { get; set; } //The page it leads to, nav prop
        public ICollection<Requirement>? Requirements { get; set; } //Undirectional relation
        public ICollection<Restriction>? Restrictions { get; set; } //Undirectional relation
        public ICollection<Reward>? Rewards { get; set; } //Undirectional relation
    }
}

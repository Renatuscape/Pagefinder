namespace PagefinderDb.Data.Models
{
    public class Restriction
    {
        public int Id { get; set; }
        public int ChoiceId { get; set; }
        public int Amount { get; set; }
        public int StoryId { get; set; }
        public int ItemId { get; set; }
        public bool IsHidden { get; set; }
        public bool SubtractOnPass { get; set; }
        public Story? Story { get; set; }  //Undirectional relation
        public Item? Item { get; set; }  //Undirectional relation
    }
}

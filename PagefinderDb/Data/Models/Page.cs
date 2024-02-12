﻿namespace PagefinderDb.Data.Models
{
    public class Page
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public string? PageTitle { get; set; }
        public string? PageText { get; set; }
        public string? ImageURL { get; set; }
        public Story? Story { get; set; }
        public ICollection<ChoicePageNavigation>? ChoicePageNavigations { get; set; }
    }
}

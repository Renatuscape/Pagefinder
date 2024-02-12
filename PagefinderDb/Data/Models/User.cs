namespace PagefinderDb.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Collection>? Collections { get; set; }
        public ICollection<Character>? Characters { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}

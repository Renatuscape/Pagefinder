using Microsoft.EntityFrameworkCore;
using PagefinderDb.Data.Models;

namespace PagefinderDb.Data
{
    public class PagefinderDbContext : DbContext
    {
        public PagefinderDbContext(DbContextOptions<PagefinderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
                .HasMany(c => c.Stories)
                .WithOne(s => s.Collection)
                .HasForeignKey(s => s.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayTest>()
                .HasOne(pt => pt.Story)
                .WithOne(s => s.PlayTest)
                .HasForeignKey<PlayTest>(pt => pt.StoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Requirement>()
                .HasOne(r => r.Story)
                .WithMany() // Assuming there's no navigation property from Story to Requirement
                .HasForeignKey(r => r.StoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Restriction>()
                .HasOne(r => r.Story)
                .WithMany() // Assuming there's no navigation property from Story to Restriction
                .HasForeignKey(r => r.StoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Reward>()
                .HasOne(r => r.Story)
                .WithMany() // Assuming there's no navigation property from Story to Reward
                .HasForeignKey(r => r.StoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<Choice> Choices { get; set; } = default!;
        public DbSet<ChoicePageNavigation> ChoicePageNavigations { get; set; } = default!;
        public DbSet<Collection> Collections { get; set; } = default!;
        public DbSet<InventoryItem> InventoryItems { get; set; } = default!;
        public DbSet<Item> Items { get; set; } = default!;
        public DbSet<Page> Pages { get; set; } = default!;
        public DbSet<PlayTest> PlayTests { get; set; } = default!;
        public DbSet<Requirement> Requirements { get; set; } = default!;
        public DbSet<Restriction> Restrictions { get; set; } = default!;
        public DbSet<Reward> Rewards { get; set; } = default!;
        public DbSet<Story> Stories { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

    }
}
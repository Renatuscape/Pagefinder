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

            modelBuilder.Entity<Choice>()
                .HasOne(c => c.SuccessPage)
                .WithMany() // Assuming there's no navigation property from Story to Requirement
                .HasForeignKey(c => c.SuccessPageId) // Specify the foreign key for SuccessPage
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Choice>()
                .HasOne(c => c.FailurePage)
                .WithMany() // Assuming there's no navigation property from Story to Requirement
                .HasForeignKey(c => c.FailurePageId) // Specify the foreign key for FailurePage
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Choice> Choices { get; set; } = default!;
        public DbSet<Collection> Collections { get; set; } = default!;
        public DbSet<Page> Pages { get; set; } = default!;
        public DbSet<Story> Stories { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

    }
}
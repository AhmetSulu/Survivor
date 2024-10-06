using Microsoft.EntityFrameworkCore;
using Survivor.Entities;

namespace Survivor.Data
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options) : base(options) { }

        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitor>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Competitors)
                .HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MiniJobBoard.Models;

namespace MiniJobBoard.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job { Id = 1, Title = "Junior .NET Developer", Company = "Acme Corp", Location = "Manila, PH", Description = "Entry level .NET role.", PostedOn = DateTime.UtcNow.AddDays(-7) },
                new Job { Id = 2, Title = "Frontend Developer", Company = "WebWorks", Location = "Remote", Description = "React/Vue experience preferred.", PostedOn = DateTime.UtcNow.AddDays(-3) }
            );
        }
    }
}

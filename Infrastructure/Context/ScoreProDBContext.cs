using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ScoreProDbContext(DbContextOptions<ScoreProDbContext> options) : DbContext(options)
    {
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScoreProDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
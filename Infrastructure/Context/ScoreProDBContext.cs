using Domain.Entities;
using Infrastructure.Context.EntityConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ScoreProDbContext(DbContextOptions<ScoreProDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContestantConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new JudgeConfiguration());
            modelBuilder.ApplyConfiguration(new CompetitionConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
        }
    }
}
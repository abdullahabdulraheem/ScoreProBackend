using Domain.Entities;
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
    }
}
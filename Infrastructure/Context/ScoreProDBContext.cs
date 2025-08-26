using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ScoreProDbContext(DbContextOptions<ScoreProDbContext> options) : IdentityDbContext<User>(options)
    {
        public 
    }
}
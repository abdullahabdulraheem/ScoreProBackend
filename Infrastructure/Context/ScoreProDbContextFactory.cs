using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class ScoreProDbContextFactory : IDesignTimeDbContextFactory<ScoreProDbContext>
    {
        public ScoreProDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("ScoreProDbContext")
                                   ?? "Host=localhost;Port=5432;Database=KSWEB;Username=postgres;Password=@Ade07025852455";

            var optionsBuilder = new DbContextOptionsBuilder<ScoreProDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ScoreProDbContext(optionsBuilder.Options);
        }
    }
}


using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class ContestantConfiguration : IEntityTypeConfiguration<Contestant>
    {
        public void Configure(EntityTypeBuilder<Contestant> builder)
        {
            builder.ToTable("Contestants");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.CompetitionId)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.TeamId)
                .HasDefaultValue(null)
                .HasMaxLength(500);

            builder.Property(c => c.AverageScore)
                .IsRequired()
                .HasDefaultValue(0)
                .HasMaxLength(500);
                
            builder.Property(c => c.TotalScore)
                .IsRequired()
                .HasDefaultValue(0)
                .HasMaxLength(500);

            builder.Property(c => c.CreatedAt)
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .IsRequired();

            // Relationships
            builder.HasOne(c => c.User)
                .WithMany() // a user can join multiple competitions
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Competition)
                .WithMany(comp => comp.Contestants)
                .HasForeignKey(c => c.CompetitionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Team)
                .WithMany(t => t.Contestants)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Scores)
                .WithOne(s => s.Contestant)
                .HasForeignKey(s => s.ContestantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
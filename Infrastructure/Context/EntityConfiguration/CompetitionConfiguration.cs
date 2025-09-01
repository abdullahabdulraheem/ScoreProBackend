using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
              builder.ToTable("Competitions");
              builder.HasKey(c => c.Id);

              builder.Property(c => c.CompetitionName)
                     .IsRequired()
                     .HasMaxLength(100);

              builder.Property(c => c.CompetitionType)
                     .IsRequired()
                     .HasMaxLength(100);

              builder.Property(c => c.Description)
                     .IsRequired()
                     .HasMaxLength(1000);

              builder.Property(c => c.CompetitionImageUrl)
                     .HasMaxLength(500)
                     .HasDefaultValue(null);

              builder.Property(c => c.CreatedByUserId)
                     .IsRequired()
                     .HasMaxLength(500);

              builder.Property(c => c.StartDate)
                     .IsRequired();

              builder.Property(c => c.EndDate)
                     .IsRequired();

              builder.Property(c => c.Status)
                     .IsRequired()
                     .HasMaxLength(50)
                     .HasDefaultValue(CompetitionStatus.NotStarted.ToString());

              builder.Property(c => c.Transparency)
                     .HasDefaultValue(false);

              builder.Property(c => c.CreatedAt)
                     .IsRequired();
                     
              // Relationships
                     builder.HasOne(c => c.CreatedBy)
                     .WithMany() // one user can create many competitions
                     .HasForeignKey(c => c.CreatedByUserId)
                     .OnDelete(DeleteBehavior.Restrict);

              builder.HasMany(c => c.AssignedJudges)
                     .WithMany(j => j.CompetitionAssignments)
                     .UsingEntity(jc => jc.ToTable("CompetitionJudges"));

              builder.HasMany(c => c.Contestants)
                     .WithOne(con => con.Competition)
                     .HasForeignKey(con => con.CompetitionId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.HasMany(c => c.ScoringCriteria)
                     .WithOne(sc => sc.Competition)
                     .HasForeignKey(sc => sc.CompetitionId)
                     .OnDelete(DeleteBehavior.Cascade);

              builder.HasMany(c => c.Teams)
                     .WithOne(t => t.Competition)
                     .HasForeignKey(t => t.CompetitionId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
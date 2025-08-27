using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class ScoreConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Scores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.ContestantId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.JudgeId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Value)
                .IsRequired()
                .HasMaxLength(50);

            // Relationships
            builder.HasOne(s => s.Contestant)
                .WithMany(c => c.Scores)
                .HasForeignKey(s => s.ContestantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Judge)
                .WithMany(j => j.Scores)
                .HasForeignKey(s => s.JudgeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: prevent duplicate Judge-Contestant scoring
            builder.HasIndex(s => new { s.ContestantId, s.JudgeId })
                .IsUnique();
        }
    }
}
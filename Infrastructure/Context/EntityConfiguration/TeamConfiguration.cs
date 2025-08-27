using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
              public void Configure(EntityTypeBuilder<Team> builder)
              {
                     builder.ToTable("Teams");

                     builder.HasKey(t => t.Id);

                     builder.Property(t => t.TeamName)
                            .IsRequired()
                            .HasMaxLength(200);

                     builder.Property(t => t.Description)
                            .HasMaxLength(500);

                     builder.Property(t => t.TeamLogoUrl)
                            .HasMaxLength(500);

                     builder.Property(t => t.CreatedAt)
                            .IsRequired();

                     builder.Property(t => t.AverageScore)
                            .HasDefaultValue(0);

                     builder.Property(t => t.CompetitionId)
                            .IsRequired();

                     builder.Property(t => t.CreatedByUserId)
                            .IsRequired();

                     // Relationships
                     builder.HasOne(t => t.Competition)
                            .WithMany(c => c.Teams)
                            .HasForeignKey(t => t.CompetitionId)
                            .OnDelete(DeleteBehavior.Cascade);

                     builder.HasMany(t => t.TeamMembers)
                            .WithOne(m => m.Team)
                            .HasForeignKey(m => m.TeamId)
                            .OnDelete(DeleteBehavior.Cascade);
                   
                     builder.HasMany(c => c.Scores)
                            .WithOne(s => s.Team)
                            .HasForeignKey(s => s.TeamId);
        }
    }
}
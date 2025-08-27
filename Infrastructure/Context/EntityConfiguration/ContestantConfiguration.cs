using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.Property(c => c.UpdatedAt)
                .HasDefaultValueSql("NOW()");

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
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(c => c.Scores)
                .WithOne(s => s.Contestant)
                .HasForeignKey(s => s.ContestantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
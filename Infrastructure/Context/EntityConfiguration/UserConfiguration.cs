using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Context.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // Properties
            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.Address)
                   .HasMaxLength(500);

            builder.Property(u => u.ProfileImageUrl)
                   .HasMaxLength(500);

            builder.Property(u => u.UserType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.CometitionsContestedIn)
                   .HasDefaultValue(0);

            builder.Property(u => u.CompetitionsWon)
                   .HasDefaultValue(0);

            builder.Property(u => u.CompetitionsJudged)
                   .HasDefaultValue(0);

            builder.Property(u => u.AllTimeRating)
                   .HasDefaultValue(0);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.UpdatedAt)
                   .IsRequired();

            // Relationships
            builder.HasMany(u => u.Competitions)
                   .WithOne(c => c.CreatedBy)
                   .HasForeignKey(c => c.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
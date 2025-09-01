using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class JudgeConfiguration : IEntityTypeConfiguration<Judge>
    {
        public void Configure(EntityTypeBuilder<Judge> builder)
        {
            builder.ToTable("Judges");
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Rating)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(j => j.User);

            builder.HasMany(j => j.Scores)
                .WithOne(s => s.Judge)
                .HasForeignKey(s => s.JudgeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(j => j.CompetitionAssignments)
                .WithMany(c => c.AssignedJudges)
                .UsingEntity(jc => jc.ToTable("CompetitionJudges")); // join table
        }

    }
}
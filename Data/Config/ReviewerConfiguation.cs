using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Config;

public class ReviewerConfiguation : IEntityTypeConfiguration<Reviewer>
{
    public void Configure(EntityTypeBuilder<Reviewer> builder)
    {
        builder.HasKey(rr => rr.Id);

        builder.Property(rr => rr.Id)
            .IsRequired();

        builder.Property(rr => rr.FirstName)
            .IsRequired();

        builder.Property(rr => rr.LastName)
            .IsRequired();

        builder.HasMany(rr => rr.Reviews)
            .WithOne(r => r.Reviewer)
            .HasForeignKey(r => r.ReviewerId)
            .IsRequired();

        builder.ToTable("Reviewers");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Config;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .IsRequired();

        builder.Property(r => r.Title)
            .IsRequired();

        builder.Property(r => r.Text)
            .IsRequired();

        builder.HasOne(r => r.Pokemon)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.PokemonId);

        builder.HasOne(r => r.Reviewer)
            .WithMany(rr => rr.Reviews)
            .HasForeignKey(r => r.ReviewerId);

        builder.ToTable("Reviews");
    }
}

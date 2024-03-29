using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Config;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .IsRequired();

        builder.Property(o => o.Name)
            .IsRequired();

        builder.Property(o => o.GYM)
            .IsRequired();

        builder.HasOne(o => o.Country)
            .WithMany(c => c.Owners)
            .HasForeignKey(o => o.CountryId);

        builder.HasMany(o => o.PokemonOwners)
            .WithOne(po => po.Owner)
            .HasForeignKey(po => po.OwnerId);

        builder.ToTable("Owners");
    }
}

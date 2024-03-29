using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Config;

public class PokemonOwnerConfiguration : IEntityTypeConfiguration<PokemonOwner>
{
    public void Configure(EntityTypeBuilder<PokemonOwner> builder)
    {
        builder.HasKey(po => new { po.OwnerId, po.PokemonId });

        builder.Property(po => po.OwnerId)
            .IsRequired();

        builder.Property(po => po.PokemonId)
            .IsRequired();

        builder.HasOne(po => po.Pokemon)
            .WithMany(p => p.PokemonOwners)
            .HasForeignKey(po => po.PokemonId)
            .IsRequired();

        builder.HasOne(po => po.Owner)
            .WithMany(o => o.PokemonOwners)
            .HasForeignKey(po => po.OwnerId)
            .IsRequired();

        builder.ToTable("PokemonOwner");
    }
}

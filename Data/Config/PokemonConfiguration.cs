using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data.Config;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.HasMany(p => p.Reviews)
            .WithOne(r => r.Pokemon)
            .HasForeignKey(r => r.PokemonId);

        builder.HasMany(p => p.PokemonOwners)
            .WithOne(po => po.Pokemon)
            .HasForeignKey(po => po.PokemonId);

        builder.HasMany(p => p.PokemonCategories)
            .WithOne(pc => pc.Pokemon)
            .HasForeignKey(pc => pc.PokemonId);

        builder.ToTable("Pokemon");
    }
}

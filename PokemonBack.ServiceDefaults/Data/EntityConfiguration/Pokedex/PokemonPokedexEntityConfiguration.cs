using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.EntityConfiguration.Pokedex
{
	public class PokemonPokedexEntityConfiguration : IEntityTypeConfiguration<PokemonPokedexEntity>
	{
		public void Configure(EntityTypeBuilder<PokemonPokedexEntity> builder)
		{
			builder.HasKey(pp => pp.Id);

			//builder.Property(pp => pp.Name)
			//	.IsRequired()
			//	.HasMaxLength(100);

			//builder.Property(pp => pp.Description)
			//	.HasMaxLength(500);

			//builder.Property(pp => pp.Element)
			//	.IsRequired();

			//builder.HasMany(pp => pp.Pokemons)
			//	.WithOne(p => p.PokemonPokedex)
			//	.HasForeignKey(p => p.Id);
		}
	}
}

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
	public class MovePokedexEntityConfiguration : IEntityTypeConfiguration<MovePokedexEntity>
	{
		public void Configure(EntityTypeBuilder<MovePokedexEntity> builder)
		{
			builder.HasKey(mp => mp.Id);

			//builder.Property(mp => mp.Name)
			//	.IsRequired()
			//	.HasMaxLength(100);

			//builder.Property(mp => mp.Description)
			//	.HasMaxLength(500);

			//builder.Property(mp => mp.Element)
			//	.IsRequired();

			//builder.HasMany(mp => mp.Moves)
			//	.WithOne(m => m.MovePokedexEntity)
			//	.HasForeignKey(m => m.Id);
		}
	}
}

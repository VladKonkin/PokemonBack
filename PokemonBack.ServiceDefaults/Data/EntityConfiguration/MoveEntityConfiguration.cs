using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.EntityConfiguration
{
	public class MoveEntityConfiguration : IEntityTypeConfiguration<MoveEntity>
	{
		public void Configure(EntityTypeBuilder<MoveEntity> builder)
		{
			builder.HasKey(m => m.Id);

			builder.HasOne(m => m.PokemonEntity)
				   .WithMany(p => p.Moves)
				   .HasForeignKey(m => m.PokemonId);


			//builder.HasOne(m => m.MovePokedexEntity)
			//	   .WithMany()
			//	   .HasForeignKey(m => m.MovePokedexId);
		}
	}
}

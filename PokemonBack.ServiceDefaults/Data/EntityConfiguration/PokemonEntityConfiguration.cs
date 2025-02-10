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
	public class PokemonEntityConfiguration : IEntityTypeConfiguration<PokemonEntity>
	{
		public void Configure(EntityTypeBuilder<PokemonEntity> builder)
		{
			builder.HasKey(p => p.Id);

			//builder.HasOne(p => p.PokemonPokedex)
			//	   .WithMany()
			//	   .HasForeignKey(p => p.PokemonPokedexId);

			builder.HasOne(p => p.User)
				   .WithMany()
				   .HasForeignKey(p => p.UserId);


			builder.HasMany(p => p.Moves)
				   .WithOne(m => m.PokemonEntity)
				   .HasForeignKey(m => m.PokemonId);
		}
	}
}

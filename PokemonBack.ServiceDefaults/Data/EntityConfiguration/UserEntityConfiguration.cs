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
	public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.HasKey(u => u.UserId);

			builder.Property(u => u.UserName)
				   .HasMaxLength(100); 

			builder.HasMany(u => u.Pokemons)
				   .WithOne(p => p.User)
				   .HasForeignKey(p => p.UserId);
		}
	}
}

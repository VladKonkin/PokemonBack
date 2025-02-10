using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PokemonBack.ServiceDefaults.Data.Entity;
using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using PokemonBack.ServiceDefaults.Data.EntityConfiguration;
using PokemonBack.ServiceDefaults.Data.EntityConfiguration.Pokedex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBack.ServiceDefaults.Data.Seed;

namespace PokemonBack.ServiceDefaults.Data.Context
{
	public class PokemonContext : DbContext
	{
		public DbSet<PokemonEntity> PokemonDBSet { get; set; }
		public DbSet<MoveEntity> MoveDBSet { get; set; }
		public DbSet<UserEntity> UserDBSet { get; set; }
		public DbSet<MovePokedexEntity> MovePokedexDbSet { get; set; }
		public DbSet<PokemonPokedexEntity> PokemonPokedexDbSet { get; set; }
		public PokemonContext(DbContextOptions<PokemonContext> options)
		: base(options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();


		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.EnableSensitiveDataLogging();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new PokemonEntityConfiguration());
			modelBuilder.ApplyConfiguration(new MoveEntityConfiguration());
			modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
			modelBuilder.ApplyConfiguration(new MovePokedexEntityConfiguration());
			modelBuilder.ApplyConfiguration(new PokemonPokedexEntityConfiguration());

		}
	}
}

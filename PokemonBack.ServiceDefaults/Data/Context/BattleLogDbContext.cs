using Microsoft.EntityFrameworkCore;
using PokemonBack.ServiceDefaults.Data.Entity;
using PokemonBack.ServiceDefaults.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Context
{
	public class BattleLogDbContext : DbContext
	{
		public DbSet<BattleLogEntity> BattleLogDbSet { get; set; }
		public BattleLogDbContext(DbContextOptions<BattleLogDbContext> options)
		: base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BattleLogEntityConfiguration());
		}
	}
}

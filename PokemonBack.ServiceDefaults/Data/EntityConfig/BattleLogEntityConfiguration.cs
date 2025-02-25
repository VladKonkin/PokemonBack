using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.EntityConfig
{
	public class BattleLogEntityConfiguration : IEntityTypeConfiguration<BattleLogEntity>
	{
		public void Configure(EntityTypeBuilder<BattleLogEntity> builder)
		{
			builder.HasKey(x => x.Id);

		}
	}
}

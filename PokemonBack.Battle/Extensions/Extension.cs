using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokemonBack.Battle.BattleMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Extensions
{
	public static class Extension
	{
		public static IHostApplicationBuilder AddBattleServices(this IHostApplicationBuilder builder)
		{
			builder.Services.AddSingleton<BattleHandler>();
			return builder;
		}
	}
}

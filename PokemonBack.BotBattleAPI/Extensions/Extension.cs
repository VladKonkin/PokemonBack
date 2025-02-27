using PokemonBack.Battle.BattleMain;
using PokemonBack.BotBattleAPI.BattleSignalR;
using PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion;
using PokemonBack.BotBattleAPI.DTO.Validator;

namespace PokemonBack.BotBattleAPI.Extensions
{
	public static class Extension
	{
		public static IHostApplicationBuilder AddSignalRServices(this IHostApplicationBuilder builder)
		{
			


			return builder;
		}
		public static IHostApplicationBuilder AddValidatorServices(this IHostApplicationBuilder builder)
		{

			builder.Services.AddScoped<ConnectToBattleValidator>();
			builder.Services.AddScoped<CreateBattleRoomValidator>();
			builder.Services.AddScoped<TurnRequestValidator>();

			builder.Services.AddScoped<BattleHubValidator>();

			return builder;
		}
	}
}

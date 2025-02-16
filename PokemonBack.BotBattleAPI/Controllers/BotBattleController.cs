using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PokemonBack.Battle.BattleMain;
using PokemonBack.ServiceDefaults.Data.Context;
using PokemonBack.ServiceDefaults.Data.Repositories;
using PokemonBack.ServiceDefaults.Data.Seed;

namespace PokemonBack.BotBattleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BotBattleController : Controller
	{
		private BattleHandler _battleHandler;
		private PokemonRepository _pokemonRepository;
		private IServiceScopeFactory _serviceScope;
        public BotBattleController(BattleHandler battleHandler, PokemonRepository pokemonRepository, IServiceScopeFactory serviceScope)
        {
            _battleHandler = battleHandler;
			_serviceScope = serviceScope;
			_pokemonRepository = pokemonRepository;	
        }
        [HttpGet("Test")]
		public IActionResult Index()
		{
			return Ok(_battleHandler.Test());
		}
		
		[HttpPut("Seed")]
		public IActionResult Test() 
		{
			using (var scope = _serviceScope.CreateScope())
			{
				var dbContext = scope.ServiceProvider.GetRequiredService<PokemonContext>();

				// Вызываем метод Seed
				dbContext.Seed();
			}
			return Ok(_battleHandler.Test());
		}
		[HttpGet("GetBattleInfoById")]
		public IActionResult GetBattleInfoById(Guid battleId)
		{
			var battle = _battleHandler.GetBattleById(battleId);

			string battleInfo = "Battle id: " + battle.Id +
				" FirstBattleMember: " + battle.FirstBattleMember + " Id: "
				+ battle.FirstBattleMember.GetId().ToString() + " ActivePok: " + battle.FirstBattleMember.ActivePokemon +
				" SecondBattleMember: " + battle.SecondBattleMember + " Id: "
				+ battle.SecondBattleMember.GetId().ToString() + " ActivePok: " + battle.SecondBattleMember.ActivePokemon;

			return Ok(battleInfo);
		}
		[HttpGet("PokemonGetTest")]
		public async Task<IActionResult> PokemonTest()
		{
			var pokemons = await _pokemonRepository.GetAllPokemonAsync();
			return Ok(pokemons);
		}
		[HttpGet("GetActiveBattles")]
		public  IActionResult GetActiveBattles()
		{
			return Ok(_battleHandler.ActiveBattles);
		}
		[HttpGet("GetActiveBattleRooms")]
		public IActionResult GetActiveBattleRooms()
		{
			return Ok(_battleHandler.ReadyBattles);
		}
		[HttpGet("GetUserIdByName")]
		public async Task<IActionResult> GetUserIdByName(string name)
		{
			var user = await _pokemonRepository.GetUserByNameAsync(name);
			return Ok(user.Id);
		}
	}
}

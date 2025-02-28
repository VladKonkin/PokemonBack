using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.BattleMembers;
using System.Text.Json.Serialization;
using System.Text.Json;
using PokemonBack.ServiceDefaults.Data.Repositories;
using PokemonBack.BotBattleAPI.DTO;
using Newtonsoft.Json;

namespace PokemonBack.BotBattleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BotBattleController : Controller
	{
		private BattleHandler _battleHandler;
		private IServiceScopeFactory _serviceScope;
		private BattleLogRepository _battleLogRepository;
		private ILogger<BotBattleController> _logger;
        public BotBattleController(BattleHandler battleHandler, IServiceScopeFactory serviceScope,BattleLogRepository battleLogRepository, ILogger<BotBattleController> logger)
        {
            _battleHandler = battleHandler;
			_serviceScope = serviceScope;
			_battleLogRepository = battleLogRepository;
			_logger = logger;
        }
	
		[HttpGet("GetUserData")]
		public IActionResult GetUserInfoById(Guid battleId,string userId)
		{
			var battle = _battleHandler.GetBattleById(battleId);

			var battleMember = (UserBattleMember)(battle.FirstBattleMember.GetId() == userId ? battle.FirstBattleMember : battle.SecondBattleMember);

			var userInfo = new UserInfoDTO
			{
				UserId = battleMember.GetId(),
				Pokemons = battleMember.PokemonList
			};

			var settings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				Formatting = Formatting.Indented
			};

			string json = JsonConvert.SerializeObject(userInfo, settings);


			return Ok(json);
		}
		[HttpGet("GetActiveBattles")]
		public  IActionResult GetActiveBattles()
		{
			var settings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				Formatting = Formatting.Indented
			};

			string json = JsonConvert.SerializeObject(_battleHandler.ActiveBattles, settings);

			return Ok(json);
		}
		[HttpGet("GetActiveBattleRooms")]
		public IActionResult GetActiveBattleRooms()
		{
			var settings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				Formatting = Formatting.Indented
			};

			string json = JsonConvert.SerializeObject(_battleHandler.ReadyBattleRooms, settings);

			return Ok(json);
		}
		[HttpGet("GetBattleLogs")]
		public IActionResult GetBattleLogs()
		{
			return Ok(_battleLogRepository.GetAllLog());
		}
		[HttpGet("Test")]
		public IActionResult Test()
		{
			return Ok("Test");
		}
		[HttpPost("CloseBattleRoomWithUser")]
		public IActionResult CloseBattleRoomWithUser(string userId)
		{
			_battleHandler.CloseBattleRoom(userId);
			return Ok();
		}
		[HttpPost("CloseBattleWithUser")]
		public IActionResult CloseBattleWithUser(string userId)
		{
			_battleHandler.CloseBattle(userId);
			return Ok();
		}
	}
}

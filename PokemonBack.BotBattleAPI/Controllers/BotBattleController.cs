using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.BattleMembers;
using System.Text.Json.Serialization;
using System.Text.Json;
using PokemonBack.ServiceDefaults.Data.Repositories;

namespace PokemonBack.BotBattleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BotBattleController : Controller
	{
		private BattleHandler _battleHandler;
		private IServiceScopeFactory _serviceScope;
		private BattleLogRepository _battleLogRepository;
        public BotBattleController(BattleHandler battleHandler, IServiceScopeFactory serviceScope,BattleLogRepository battleLogRepository)
        {
            _battleHandler = battleHandler;
			_serviceScope = serviceScope;
			_battleLogRepository = battleLogRepository;
        }
	
		[HttpGet("GetUserData")]
		public IActionResult GetUserInfoById(Guid battleId,string userId)
		{
			var battle = _battleHandler.GetBattleById(battleId);

			var battleMember = (UserBattleMember)(battle.FirstBattleMember.GetId() == userId ? battle.FirstBattleMember : battle.SecondBattleMember);
			
			return Ok(battleMember.GetTestUserJson());
		}
		[HttpGet("GetActiveBattles")]
		public  IActionResult GetActiveBattles()
		{
			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve, 
			};

			string json = JsonSerializer.Serialize(_battleHandler.ActiveBattles, options);

			return Ok(json);
		}
		[HttpGet("GetActiveBattleRooms")]
		public IActionResult GetActiveBattleRooms()
		{
			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve,
			};

			string json = JsonSerializer.Serialize(_battleHandler.ReadyBattleRooms, options);

			return Ok(json);
		}
		[HttpGet("GetBattleLogs")]
		public IActionResult GetBattleLogs()
		{
			return Ok(_battleLogRepository.GetAllLog());
		}
		[HttpPost("CloseBattleRoomWithUser")]
		public IActionResult CloseBattleRoomWithUser(string userId)
		{
			_battleHandler.CloseBattleRoom(userId);
			return Ok();
		}
	}
}

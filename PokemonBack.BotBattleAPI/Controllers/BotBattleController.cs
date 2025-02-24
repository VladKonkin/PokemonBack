using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.BattleMembers;

namespace PokemonBack.BotBattleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BotBattleController : Controller
	{
		private BattleHandler _battleHandler;
		private IServiceScopeFactory _serviceScope;
        public BotBattleController(BattleHandler battleHandler, IServiceScopeFactory serviceScope)
        {
            _battleHandler = battleHandler;
			_serviceScope = serviceScope;
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
			return Ok(_battleHandler.ActiveBattles);
		}
		[HttpGet("GetActiveBattleRooms")]
		public IActionResult GetActiveBattleRooms()
		{
			return Ok(_battleHandler.ReadyBattles);
		}
	}
}

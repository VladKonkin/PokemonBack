using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.BotBattleAPI.DTO;
using PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion;
using PokemonBack.BotBattleAPI.DTO.Validator;

namespace PokemonBack.BotBattleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BotBattleController : Controller
	{
        private BattleHandler _battleHandler;
		private TurnRequestValidator _turnRequestValidator;
        public BotBattleController(BattleHandler battleHandler, TurnRequestValidator turnRequestValidator)
        {
            _battleHandler = battleHandler;
			_turnRequestValidator = turnRequestValidator;
        }

		[HttpGet("CreateBattle")]
        public async Task<IActionResult> CreateBattle(string userId)
        {
            var battle = await _battleHandler.CreateBotBattle(userId);

			var settings = new JsonSerializerSettings
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				Formatting = Formatting.Indented
			};

			string json = JsonConvert.SerializeObject(battle, settings);

			return Ok(json);
        }
		[HttpPost("SendTurn")]
        public async Task<IActionResult> SendTurn(TurnRequestDTO moveRequest)
        {
			var validationResult = await _turnRequestValidator.ValidateAsync(moveRequest);

			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
			}

			var battleMember = _battleHandler.GetBattleMemberById(moveRequest.PlayerId);

			if (moveRequest.MoveId == null | moveRequest.MoveId == "")
			{
				var switchData = new SwitchAction(moveRequest.NewPokemonId, battleMember);

				battleMember.SetTurnData(switchData);
			}
			else
			{
				battleMember.SetMoveId(moveRequest.MoveId);
			}

			return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.ServiceDefaults.Auth;
using System.Net.WebSockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PokemonBack.BotBattleAPI.BattleSignalR
{
	
	public class BattleHub : Hub
	{
        private BattleHandler _battleHandler;
        private BattleManager _battleManager;
		private JWTTokenGenerator _jwtTokenGenerator;
        public BattleHub(BattleHandler battleHandler,BattleManager battleManager,JWTTokenGenerator jWTTokenGenerator)
        {
            _battleHandler = battleHandler;
			_battleManager = battleManager;
			_jwtTokenGenerator = jWTTokenGenerator;

		}
        public async Task ConnectToBattleRoom(Guid battleId,Guid userId)
        {
            var connectionId = Context.ConnectionId;
            await Groups.AddToGroupAsync(connectionId, battleId.ToString());
            var battle = await _battleHandler.ConnectToBattleRoom(battleId, userId);

			var token = _jwtTokenGenerator.GenerateToken(userId, battleId);
			await Clients.Caller.SendAsync("TokenGenerated", token);

			await Clients.Group(battleId.ToString()).SendAsync("Connect", battle.FirstBattleMember.GetId(),battle.SecondBattleMember.GetId());
        }
        public async Task CreateBattleRoom(Guid userId)
        {
            var battleRoom = await _battleHandler.CreateBattleRoom(userId);
            Console.WriteLine(battleRoom + " BattleRoom");
            var battleId = battleRoom.BattleID;

			var connectionId = Context.ConnectionId;
			await Groups.AddToGroupAsync(connectionId, battleId.ToString());

			var token = _jwtTokenGenerator.GenerateToken(userId, battleId);
			await Clients.Caller.SendAsync("TokenGenerated", token);

			_battleManager.RegisterBattle(battleId, Clients.Group(battleId.ToString()));
			

            await Clients.Group(battleId.ToString()).SendAsync("BattleRoomCreated",battleId);
        }
        public async Task MakeMove(Guid battleId,Guid battleMemberId,Guid moveId)
        {
            var battleMember = _battleHandler.GetBattleMemberById(battleMemberId);
            battleMember.SetMoveId(moveId);
            await Clients.Group(battleId.ToString()).SendAsync("Move was Set",moveId);
        }

		public async Task SendTurn(JsonMoveRequest moveRequest)
		{
			if (moveRequest == null)
			{
				throw new ArgumentNullException(nameof(moveRequest));
			}
			var battleMember = _battleHandler.GetBattleMemberById(moveRequest.PlayerId);

			if (moveRequest.MoveId == null)
			{
				Guid pokemonId = (Guid)moveRequest.NewPokemonId;

				var switchData = new SwitchAction(pokemonId, battleMember);

				battleMember.SetTurnData(switchData);
			}
			else
			{
				battleMember.SetMoveId(moveRequest.MoveId);
			}

			await Clients.Group(moveRequest.BattleId.ToString()).SendAsync("TurnSet");
		}
		//[Authorize]
		//public async Task SendTurn(JsonMoveRequest moveRequest)
		//{
		//	var userId = Guid.Parse(Context.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
		//	var battleId = Guid.Parse(Context.User.Claims.FirstOrDefault(c => c.Type == "BattleId")?.Value);

		//	if (moveRequest == null)
		//	{
		//		throw new ArgumentNullException(nameof(moveRequest));
		//	}
		//	var battleMember = _battleHandler.GetBattleMemberById(userId);

		//	if (moveRequest.MoveId == null)
		//	{
		//		Guid pokemonId = (Guid)moveRequest.NewPokemonId;

		//		var switchData = new SwitchAction(pokemonId, battleMember);

		//		battleMember.SetTurnData(switchData);
		//	}
		//	else
		//	{
		//		battleMember.SetMoveId(moveRequest.MoveId);
		//	}

		//	await Clients.Group(battleId.ToString()).SendAsync("TurnSet");
		//}
		public async Task Test()
        {
			await Clients.All.SendAsync("Test", "Test");
		}
        public async Task OnBattleStateChange(Guid battleId,StateLogBase stateLog)
        {
            var turnJson = JsonConvert.SerializeObject(stateLog);

            await Clients.Group(battleId.ToString()).SendAsync(turnJson);
        }
    }
}

using FluentValidation;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.BotBattleAPI.DTO;
using PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion;
using PokemonBack.BotBattleAPI.DTO.Validator;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PokemonBack.BotBattleAPI.BattleSignalR
{
	public class BattleHub : Hub
	{
        private BattleHandler _battleHandler;
        private BattleManager _battleManager;

        private BattleHubValidator _battleHubValidator;

        public BattleHub(BattleHandler battleHandler,BattleManager battleManager,BattleHubValidator battleHubValidator)
        {
            _battleHandler = battleHandler;
			_battleManager = battleManager;
            _battleHubValidator = battleHubValidator;
		}
        public async Task ConnectToBattleRoom(ConnectToBattleDTO connetToBattleDTO)
        {
            var validator = _battleHubValidator.GetConnectToBattleValidator();
			var validationResult = await validator.ValidateAsync(connetToBattleDTO);

            if (!validationResult.IsValid)
            {
				await Clients.Caller.SendAsync("ReceiveError", validationResult.Errors.Select(e => e.ErrorMessage));
				return;
			}


            var connectionId = Context.ConnectionId;
            await Groups.AddToGroupAsync(connectionId, connetToBattleDTO.BattleId.ToString());
            var battle = await _battleHandler.ConnectToBattleRoom(connetToBattleDTO.BattleId, connetToBattleDTO.UserId);

			await Clients.Group(connetToBattleDTO.BattleId.ToString()).SendAsync("Connect", battle.FirstBattleMember.GetId(),battle.SecondBattleMember.GetId());
        }
        public async Task CreateBattleRoom(CreateBattleRoomDTO createBattleRoomDTO)
        {
			var validator = _battleHubValidator.GetCreateBattleRoomValidator();
			var validationResult = await validator.ValidateAsync(createBattleRoomDTO);

			if (!validationResult.IsValid)
			{
				await Clients.Caller.SendAsync("ReceiveError", validationResult.Errors.Select(e => e.ErrorMessage));
				return;
			}



			var battleRoom = await _battleHandler.CreateBattleRoom(createBattleRoomDTO.UserId);
            Console.WriteLine(battleRoom + " BattleRoom");
            var battleId = battleRoom.BattleID;

			var connectionId = Context.ConnectionId;
			await Groups.AddToGroupAsync(connectionId, battleId.ToString());

            _battleManager.RegisterBattle(battleId, Clients.Group(battleId.ToString()));
			

            await Clients.Group(battleId.ToString()).SendAsync("BattleRoomCreated",battleId);
        }
		public async Task SendTurn(TurnRequestDTO moveRequest)
		{
			var validator = _battleHubValidator.GetTurnRequestValidator();
			var validationResult = await validator.ValidateAsync(moveRequest);

			if (!validationResult.IsValid)
			{
				await Clients.Caller.SendAsync("ReceiveError", validationResult.Errors.Select(e => e.ErrorMessage));
				return;
			}


			var battleMember = _battleHandler.GetBattleMemberById(moveRequest.PlayerId);
			string? validationError = null;


			Action<string> onValidationError = (error) =>
			{
				validationError = error;
			};

			if (moveRequest.MoveId == null)
            {
				var switchData = new SwitchAction(moveRequest.NewPokemonId, battleMember);

                battleMember.SetTurnData(switchData, onValidationError);
            }
            else
            {
                battleMember.SetMoveId(moveRequest.MoveId, onValidationError);
            }

			if (validationError != null)
			{
				await Clients.Caller.SendAsync("ReceiveError", validationError);
			}

			await Clients.Group(moveRequest.BattleId.ToString()).SendAsync("TurnSet");
		}
		public async Task Test()
        {
			await Clients.All.SendAsync("Test", "Test");
		}
		public override Task OnDisconnectedAsync(Exception? exception)
		{


			return base.OnDisconnectedAsync(exception);
		}
	}
}

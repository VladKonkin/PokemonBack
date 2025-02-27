using FluentValidation;
using PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion;

namespace PokemonBack.BotBattleAPI.DTO.Validator
{
	public class BattleHubValidator
	{
        private  ConnectToBattleValidator _connectToBattle;
        private  CreateBattleRoomValidator _createBattleRoom;
        private  TurnRequestValidator _turnRequest;
        public BattleHubValidator(ConnectToBattleValidator connectToBattle,
			CreateBattleRoomValidator createBattleRoom,
			TurnRequestValidator turnRequest)
        {
            _connectToBattle = connectToBattle;
            _createBattleRoom = createBattleRoom;
            _turnRequest = turnRequest;
            
        }

        public ConnectToBattleValidator GetConnectToBattleValidator()  
        {
            return _connectToBattle;
        }
        public CreateBattleRoomValidator GetCreateBattleRoomValidator()
        {
            return _createBattleRoom;
        }
        public TurnRequestValidator GetTurnRequestValidator()
        {
            return _turnRequest;
        }
    }
}

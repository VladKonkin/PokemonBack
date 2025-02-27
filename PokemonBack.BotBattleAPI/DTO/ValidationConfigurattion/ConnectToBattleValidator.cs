using FluentValidation;
using PokemonBack.Battle.BattleMain;

namespace PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion
{
	public class ConnectToBattleValidator : AbstractValidator<ConnectToBattleDTO>
	{
        private BattleHandler _battleHandler;
        public ConnectToBattleValidator(BattleHandler battleHandler)
        {
            _battleHandler = battleHandler;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is empty")
				.Must(userId => NotInBattle(userId))
			.WithMessage("Already in battle");

			RuleFor(x => x.BattleId)
                .NotEmpty().WithMessage("BattleId is empty");
        }

        private bool NotInBattle(string userId)
        {
           var battleRoomWithUser = _battleHandler.ReadyBattleRooms.FirstOrDefault(u => u.FirstBattleMember.GetId() == userId);
           var battleWithUser = _battleHandler.ActiveBattles.FirstOrDefault(u => u.FirstBattleMember.GetId() == userId | u.SecondBattleMember.GetId() == userId);
            
            return battleRoomWithUser == null & battleWithUser == null;
        }
    }
}

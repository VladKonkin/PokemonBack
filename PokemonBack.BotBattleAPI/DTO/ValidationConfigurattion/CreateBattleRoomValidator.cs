using FluentValidation;
using PokemonBack.Battle.BattleMain;

namespace PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion
{
	public class CreateBattleRoomValidator : AbstractValidator<CreateBattleRoomDTO>
	{
        private BattleHandler _battleHandler;
        public CreateBattleRoomValidator(BattleHandler battleHandler)
        {
            _battleHandler = battleHandler;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is empty")
				.Must(userId => NotInBattle(userId)).WithMessage("User in battle");

        }
		private bool NotInBattle(string userId)
		{
			var battleRoomWithUser = _battleHandler.ReadyBattleRooms.FirstOrDefault(u => u.FirstBattleMember.GetId() == userId);
			var battleWithUser = _battleHandler.ActiveBattles.FirstOrDefault(u => u.FirstBattleMember.GetId() == userId | u.SecondBattleMember.GetId() == userId);

			return battleRoomWithUser == null & battleWithUser == null;
		}
	}
}

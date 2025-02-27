using FluentValidation;

namespace PokemonBack.BotBattleAPI.DTO.ValidationConfigurattion
{
	public class TurnRequestValidator : AbstractValidator<TurnRequestDTO>
	{
        public TurnRequestValidator()
        {
            RuleFor(x => x.BattleId)
                .NotEmpty().WithMessage("BattleId is empty");

            RuleFor(x => x.PlayerId)
                .NotEmpty().WithMessage("UserId is empty");
        }

    }
}

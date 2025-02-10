using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public class SwitchAction : TurnAction
	{
		public PokemonDTO NewPokemon { get; }

		public SwitchAction(Guid pokemonId)
		{
			NewPokemon = BattleMember.GetPokemonById(pokemonId);
		}

		public override string Description => $"Покемон сменяется на {NewPokemon}";

		public override void Execute(BattleMember target)
		{
			BattleMember.ChoosePokemon(NewPokemon);
		}

		public override void Execute()
		{
			BattleMember.ChoosePokemon(NewPokemon); 
		}
	}
}


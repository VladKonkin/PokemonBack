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
		public PokemonDTO NewPokemon { get; private set; }
		private Guid PokemonId { get; set; }
		private BattleMember _battleMember;
		public override string Description => $"Покемон сменяется на {NewPokemon}";
		public override BattleMember? BattleMember => _battleMember; 
		public SwitchAction(Guid pokemonId,BattleMember battleMember)
		{
			Priority = 10;
			PokemonId = pokemonId;
			_battleMember = battleMember;
			NewPokemon = _battleMember.GetPokemonById(pokemonId);
		}


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


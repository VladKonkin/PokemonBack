using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public class MoveAction : TurnAction
	{
		public PokemonDTO PokemonDTO { get; }
		public MoveDTO MoveDTO { get; }

		public MoveAction(PokemonDTO pokemon, MoveDTO move)
		{
			PokemonDTO = pokemon;
			MoveDTO = move;
		}

		public override string Description => $"{Pokemon} use {Move}";

		public override PokemonDTO Pokemon => Pokemon;
		public override MoveDTO Move => Move;

		public override void Execute(BattleMember target)
		{
			target.ActivePokemon.CurrentHp -= MoveDTO.Power;
			MoveDTO.CurrentPP--;
		}

		public override void Execute()
		{
			throw new NotImplementedException();
		}
	}
}

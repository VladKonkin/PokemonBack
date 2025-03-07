using PokemonBack.Battle.BattleCalculator;
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
		public PokemonModel PokemonDTO { get; }
		public MoveModel MoveDTO { get; }

		public override string Description => $"{Pokemon} use {Move}";

		public override PokemonModel Pokemon => PokemonDTO;
		public override MoveModel Move => MoveDTO;
		public MoveAction(PokemonModel pokemon, MoveModel move)
		{
			Priority = 1;
			PokemonDTO = pokemon;
			MoveDTO = move;
		}

		protected double GetTypeModificator(PokemonModel target)
		{
			double typeModificator = TypeEffectiveness.GetEffectiveness(MoveDTO.AttackType, target.PokemonType);
			if (target.SecondPokemonType != null)
			{
				typeModificator *= TypeEffectiveness.GetEffectiveness(MoveDTO.AttackType, target.SecondPokemonType);
			}
			return typeModificator;
		}
		
		public override void Execute(BattleMember target)
		{
			double typeModifier = GetTypeModificator(target.ActivePokemon);

			int damage = (int)(MoveDTO.Power * typeModifier);

			target.ActivePokemon.CurrentHp -= damage;
			MoveDTO.CurrentPP--;
		}

		public override void Execute()
		{
			throw new NotImplementedException();
		}
	}
}

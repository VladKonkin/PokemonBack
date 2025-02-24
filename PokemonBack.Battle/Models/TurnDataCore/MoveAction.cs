﻿using PokemonBack.Battle.BattleCalculator;
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

		public override string Description => $"{Pokemon} use {Move}";

		public override PokemonDTO Pokemon => PokemonDTO;
		public override MoveDTO Move => MoveDTO;
		public MoveAction(PokemonDTO pokemon, MoveDTO move)
		{
			Priority = 1;
			PokemonDTO = pokemon;
			MoveDTO = move;
		}

		
		public override void Execute(BattleMember target)
		{
			double typeModifier = TypeEffectiveness.GetEffectiveness(PokemonDTO.Element, target.ActivePokemon.Element);
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

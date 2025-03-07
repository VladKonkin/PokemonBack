using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public class PhysicalMoveAction : MoveAction
	{
		public PhysicalMoveAction(PokemonModel pokemon, MoveModel move) : base(pokemon, move)
		{

		}
	}
}

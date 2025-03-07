using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public class StatusMoveAction : MoveAction
	{
		public StatusMoveAction(PokemonModel pokemon, MoveModel move) : base(pokemon, move)
		{

		}
	}
}

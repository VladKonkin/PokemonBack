using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
    public class TurnData
    {
		public TurnAction Action { get; }

		public TurnData(TurnAction action)
		{
			Action = action ?? throw new ArgumentNullException(nameof(action));
		}

		public PokemonDTO? Pokemon => Action.Pokemon;
		public MoveDTO? Move => Action.Move;
	}
}

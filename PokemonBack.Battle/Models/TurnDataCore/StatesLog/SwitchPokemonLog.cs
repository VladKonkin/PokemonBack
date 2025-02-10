using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class SwitchPokemonLog : StateLogBase
	{
		public Guid PlayerId { get; set; }
		public Guid PreviousPokemonId { get; set; }
		public Guid NewPokemonId { get; set; }

		public SwitchPokemonLog(Guid playerId, Guid previousPokemonId, Guid newPokemonId)
			: base("SwitchPokemon")
		{
			PlayerId = playerId;
			PreviousPokemonId = previousPokemonId;
			NewPokemonId = newPokemonId;
		}
	}
}

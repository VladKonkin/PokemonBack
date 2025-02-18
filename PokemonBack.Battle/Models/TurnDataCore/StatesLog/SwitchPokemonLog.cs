using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class SwitchPokemonLog : StateLogBase
	{
		[JsonProperty] public Guid PlayerId { get; set; }
		[JsonProperty] public Guid PreviousPokemonId { get; set; }
		[JsonProperty] public Guid NewPokemonId { get; set; }

		public SwitchPokemonLog(Guid playerId, Guid previousPokemonId, Guid newPokemonId)
			: base("SwitchPokemon")
		{
			PlayerId = playerId;
			PreviousPokemonId = previousPokemonId;
			NewPokemonId = newPokemonId;
		}
	}
}

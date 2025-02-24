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
		[JsonProperty] public string PlayerId { get; set; }
		[JsonProperty] public string PreviousPokemonId { get; set; }
		[JsonProperty] public string NewPokemonId { get; set; }

		public SwitchPokemonLog(string playerId, string previousPokemonId, string newPokemonId)
			: base("SwitchPokemon")
		{
			PlayerId = playerId;
			PreviousPokemonId = previousPokemonId;
			NewPokemonId = newPokemonId;
		}
	}
}

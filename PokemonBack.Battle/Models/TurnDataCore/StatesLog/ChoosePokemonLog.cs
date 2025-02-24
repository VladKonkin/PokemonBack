using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class ChoosePokemonLog : StateLogBase
	{
		[JsonProperty] public string FirstPlayerId { get; set; }
		[JsonProperty] public string FirstPokemonId { get; set; }
		[JsonProperty] public string SecondPlayerId { get; set; }
		[JsonProperty] public string SecondPokemonId { get; set; }
		public ChoosePokemonLog(string firstPlayerId, string firstPokemonId, string secondPlayerId, string secondPokemonId) : base("PokemonChoose")
		{
			FirstPlayerId = firstPlayerId;
			FirstPokemonId = firstPokemonId;

			SecondPlayerId = secondPlayerId;
			SecondPokemonId = secondPokemonId;
		}
	}
}

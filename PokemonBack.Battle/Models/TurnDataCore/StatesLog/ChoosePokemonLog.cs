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
		[JsonProperty] public Guid FirstPlayerId { get; set; }
		[JsonProperty] public Guid FirstPokemonId { get; set; }
		[JsonProperty] public Guid SecondPlayerId { get; set; }
		[JsonProperty] public Guid SecondPokemonId { get; set; }
		public ChoosePokemonLog(Guid firstPlayerId,Guid firstPokemonId, Guid secondPlayerId, Guid secondPokemonId) : base("PokemonChoose")
		{
			FirstPlayerId = firstPlayerId;
			FirstPokemonId = firstPokemonId;

			SecondPlayerId = secondPlayerId;
			SecondPokemonId = secondPokemonId;
		}
	}
}

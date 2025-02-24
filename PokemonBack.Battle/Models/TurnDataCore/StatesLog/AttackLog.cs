using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{

	public class AttackLog : StateLogBase
	{
		[JsonProperty] public string PlayerId { get; set; }
		[JsonProperty] public string PokemonId { get; set; }
		[JsonProperty] public string MoveId { get; set; }
		[JsonProperty] public string TargetPokemonId { get; set; }
		[JsonProperty] public int DamageDealt { get; set; }

		public AttackLog(string playerId, string pokemonId, string moveId, string targetPokemonId, int damageDealt)
			: base("Attack")
		{
			PlayerId = playerId;
			PokemonId = pokemonId;
			MoveId = moveId;
			TargetPokemonId = targetPokemonId;
			DamageDealt = damageDealt;
		}
	}
}

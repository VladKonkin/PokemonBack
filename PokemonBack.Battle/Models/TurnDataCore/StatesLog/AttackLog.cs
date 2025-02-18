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
		[JsonProperty] public Guid PlayerId { get; set; }
		[JsonProperty] public Guid PokemonId { get; set; }
		[JsonProperty] public Guid MoveId { get; set; }
		[JsonProperty] public Guid TargetPokemonId { get; set; }
		[JsonProperty] public int DamageDealt { get; set; }

		public AttackLog(Guid playerId, Guid pokemonId, Guid moveId, Guid targetPokemonId, int damageDealt)
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

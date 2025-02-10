using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{

	internal class AttackLog : StateLogBase
	{
		public Guid PlayerId { get; set; }
		public Guid PokemonId { get; set; }
		public Guid MoveId { get; set; }
		public Guid TargetPokemonId { get; set; }
		public int DamageDealt { get; set; }

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

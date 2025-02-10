using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	internal class ChoosePokemonLog : StateLogBase
	{
		public Guid FirstPlayerId { get; set; }
		public Guid FirstPokemonId { get; set; }
		public Guid SecondPlayerId { get; set; }
		public Guid SecondPokemonId { get; set; }
		public ChoosePokemonLog(Guid firstPlayerId,Guid firstPokemonId, Guid secondPlayerId, Guid secondPokemonId) : base("PokemonChoose")
		{
			FirstPlayerId = firstPlayerId;
			FirstPokemonId = firstPokemonId;

			SecondPlayerId = secondPlayerId;
			SecondPokemonId = secondPokemonId;
		}
	}
}

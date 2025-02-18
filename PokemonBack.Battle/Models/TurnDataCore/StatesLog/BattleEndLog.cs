using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class BattleEndLog : StateLogBase
	{
		[JsonProperty] public Guid BattleId { get; set; }
		public BattleEndLog(Guid battleId) : base("BattleEnd")
		{
			BattleId = battleId;
		}
	}
}

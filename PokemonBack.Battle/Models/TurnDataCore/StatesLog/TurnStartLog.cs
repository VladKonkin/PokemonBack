using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class TurnStartLog : StateLogBase
	{
		[JsonProperty] public int TurnNumber { get; set; }
		public TurnStartLog(int turnNumber) : base("TurnStart")
		{
			TurnNumber = turnNumber;
		}
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class CalculateLog : StateLogBase
	{
		[JsonProperty] public StateLogBase FirstPlayerLog { get; set; }
		[JsonProperty] public StateLogBase SecondPlayerLog { get; set; }
		public CalculateLog(StateLogBase first,StateLogBase second) : base("Calculate")
		{
			FirstPlayerLog = first;
			SecondPlayerLog = second;
		}
	}
}

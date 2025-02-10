using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	internal class CalculateLog : StateLogBase
	{
		public StateLogBase FirstPlayerLog { get; set; }
		public StateLogBase SecondPlayerLog { get; set; }
		public CalculateLog(StateLogBase first,StateLogBase second) : base("Calculate")
		{
			FirstPlayerLog = first;
			SecondPlayerLog = second;
		}
	}
}

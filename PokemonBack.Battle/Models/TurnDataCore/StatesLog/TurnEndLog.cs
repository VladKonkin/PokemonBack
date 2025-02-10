using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class TurnEndLog : StateLogBase
	{
		public int TurnNumber;
		public TurnEndLog(int turnNumber) : base("TurnEnd")
		{
			TurnNumber = turnNumber;
		}
	}
}

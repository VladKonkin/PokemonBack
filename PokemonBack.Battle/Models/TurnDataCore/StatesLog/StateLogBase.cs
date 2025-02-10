using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public abstract class StateLogBase
	{
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;
		public string ActionType { get; set; }

		protected StateLogBase(string actionType)
		{
			ActionType = actionType;
		}
	}
}

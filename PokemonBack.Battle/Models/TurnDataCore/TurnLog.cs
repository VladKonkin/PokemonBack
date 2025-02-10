using Newtonsoft.Json;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public class TurnLog
	{
		[JsonProperty] public int TurnNumber {  get; set; }
		[JsonProperty] public List<StateLogBase> StateLogList { get; set; }
        public TurnLog(int turnNumber)
        {
            TurnNumber = turnNumber;
			StateLogList = new List<StateLogBase>();
		}
		public void AddStateLog(StateLogBase stateLog)
		{
			StateLogList.Add(stateLog);
		}
    }
}

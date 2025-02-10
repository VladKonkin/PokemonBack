using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.Battle.Models.TurnDataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain
{
    public class BattleLoger
    {
		private BattleSession _battle;
		public TurnLog ActiveTurnLog { get; private set; }

		private List<TurnLog> _battleLogList;
		public BattleLoger(BattleSession battle)
        {
			_battle = battle;

			_battleLogList = new List<TurnLog>();
			ActiveTurnLog = new TurnLog(_battle.TurnNumber);
			_battleLogList.Add(ActiveTurnLog);
		}
		public void AddStateLog(StateLogBase stateLog)
		{
			ActiveTurnLog.AddStateLog(stateLog);
			_battle.OnStateChange(stateLog);
		}
	}
}

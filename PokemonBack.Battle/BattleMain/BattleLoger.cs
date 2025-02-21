using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using PokemonBack.Battle.Models.TurnDataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonBack.Battle.BattleMain
{
    public class BattleLoger
    {
		private BattleSession _battle;
		private TurnLog _activeTurnLog;

		private List<TurnLog> _battleLogList;
		public BattleLoger(BattleSession battle)
        {
			_battle = battle;

			_battleLogList = new List<TurnLog>();
			_activeTurnLog = new TurnLog(_battle.TurnNumber);
			_battleLogList.Add(_activeTurnLog);

			SubscribeBattleActions();
		}
		private void AddStateLog(Guid battleId, StateLogBase stateLog)
		{
			_activeTurnLog.AddStateLog(stateLog);
		}
		private void SubscribeBattleActions()
		{
			_battle.OnStateChangeAction += AddStateLog;
			_battle.OnBattleEndAction += OnBattleEnd;
			_battle.OnTurnEndAction += OnTurnEnd;
		}
		private void UnSubscribeBattleActions()
		{
			_battle.OnStateChangeAction -= AddStateLog;
			_battle.OnBattleEndAction -= OnBattleEnd;
			_battle.OnTurnEndAction -= OnTurnEnd;
		}
		private void OnBattleEnd(BattleSession battle)
		{
			UnSubscribeBattleActions();
			ToJson();
		}
		private void OnTurnEnd()
		{
			_activeTurnLog = new TurnLog(_battle.TurnNumber);
			_battleLogList.Add(_activeTurnLog);
		}
		private void ToJson()
		{
			string battleLogJson = JsonConvert.SerializeObject(_battleLogList, Formatting.Indented);
			Console.WriteLine(battleLogJson);
		}
	}
}

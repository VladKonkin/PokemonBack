using Microsoft.AspNetCore.SignalR;
using PokemonBack.Battle.BattleMain;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;

namespace PokemonBack.BotBattleAPI.BattleSignalR
{
	public class BattleManager : IDisposable
	{
        private BattleHandler _battleHandler;

		private readonly Dictionary<Guid, IClientProxy> _clients = new();
		public BattleManager(BattleHandler battleHandler)
        {
            _battleHandler = battleHandler;
			SubscribeBattleAction();

		}
		private void SubscribeBattleAction()
		{
			_battleHandler.BattleStateChanged += BattleStateChanged;
			_battleHandler.OnBattleEnd += UnregisterBattle;
		}
		private void UnSubscribeBattleAction()
		{
			_battleHandler.BattleStateChanged -= BattleStateChanged;
			_battleHandler.OnBattleEnd -= UnregisterBattle;
		}
		public void RegisterBattle(Guid battleId, IClientProxy clients)
		{
			if (!_clients.ContainsKey(battleId))
			{
				_clients[battleId] = clients;
			}
		}
		private void BattleStateChanged(Guid battleId,StateLogBase stateLog)
		{
			_clients[battleId].SendAsync("StateChanged",stateLog);
		}
		private void UnregisterBattle(Guid battleId)
		{
			_clients.Remove(battleId);
		}

		public void Dispose()
		{
			UnSubscribeBattleAction();
		}
	}
}

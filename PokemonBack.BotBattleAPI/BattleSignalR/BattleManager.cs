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
            Console.WriteLine("BattleRegister " + battleId);
            if (!_clients.ContainsKey(battleId))
			{
				Console.WriteLine("BattleRegisterIf " + battleId);
				_clients[battleId] = clients;
			}
		}
		private void BattleStateChanged(Guid battleId,StateLogBase stateLog)
		{
            Console.WriteLine("BattleStateChanged: " + battleId + " " + stateLog.ToJson());
            _clients[battleId].SendAsync("StateChanged",stateLog.ToJson());
		}
		private void UnregisterBattle(BattleSession battle)
		{
            Console.WriteLine($"Battle with id {battle.Id} end");
			_clients.Remove(battle.Id);
		}

		public void Dispose()
		{
			UnSubscribeBattleAction();
		}
	}
}

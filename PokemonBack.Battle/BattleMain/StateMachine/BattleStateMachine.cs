using PokemonBack.Battle.BattleMain.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine
{
	public class BattleStateMachine 
	{
		private BattleSession _batle;
		private List<BattleStateBase> _stateList;
		private BattleStateBase _activeState;
        public BattleStateMachine(BattleSession battle)
        {
            _batle = battle;

			_stateList = new List<BattleStateBase>
			{
				new BattleStartState(this,_batle),
				new BattlePokemonChooseState(this,_batle),
				new BattleTurnStartState(this,_batle),
				new BattleCalculateState(this,_batle),
				new BattleTurnEndState(this,_batle),
				new BattleTurnSwitchWaitState(this,_batle),
				new BattleEndState(this,_batle)

			};
			SwitchState<BattleStartState>();
        }
        public void SwitchState<T>() where T : BattleStateBase
		{
			_activeState?.OnStop();
			SetStateLog();
			_activeState = _stateList.FirstOrDefault(s => s is T);
			_activeState.OnStart();
		}
		private void SetStateLog()
		{
			//_batle?.BattleLoger?.AddStateLog(_activeState?.StateLog);
		}
	}
}

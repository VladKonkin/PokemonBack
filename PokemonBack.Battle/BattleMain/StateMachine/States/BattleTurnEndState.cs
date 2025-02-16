using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattleTurnEndState : BattleStateBase
	{
		public BattleTurnEndState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{
		}

		public override void OnBattleMemberAction()
		{
			
		}

		public override void OnStart()
		{
			StateLog = new TurnEndLog(_battle.TurnNumber);
			_battle.OnStateChange(StateLog);

			_battle.OnTurnEnd();
			_battleStateMachine.SwitchState<BattleTurnStartState>();
		}

		public override void OnStop()
		{
			
		}
	}
}

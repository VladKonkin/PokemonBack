using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattleTurnStartState : BattleStateBase
    {
		public BattleTurnStartState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{
		}

		public override void OnBattleMemberAction()
		{
			ActionReadyCheck();
		}

		public override void OnStart()
        {
			StateLog = new TurnStartLog(_battle.TurnNumber);
			_battle.OnStateChangeAction(StateLog);

			BattleMemberActionSubscribe();
        }

        public override void OnStop()
        {
			BattleMemberActionUnSubscribe();
        }
		private void ActionReadyCheck()
		{
			if (_battle.FirstBattleMember.IsReady() & _battle.SecondBattleMember.IsReady())
			{
				_battleStateMachine.SwitchState<BattleCalculateState>();
			}
		}
    }
}

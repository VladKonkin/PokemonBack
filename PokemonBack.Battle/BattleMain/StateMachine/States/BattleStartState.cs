using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
    public class BattleStartState : BattleStateBase
    {
		public BattleStartState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{

		}

		public override void OnBattleMemberAction()
		{
          

		}

		public override void OnStart()
        {
			StateLog = new BattleStartLog(_battle.FirstBattleMember.GetId(),
				_battle.SecondBattleMember.GetId(),
				_battle.Id);
			_battle.OnStateChange(StateLog);
			_battleStateMachine.SwitchState<BattlePokemonChooseState>();
        }

        public override void OnStop()
        {
			
		}
    }
}

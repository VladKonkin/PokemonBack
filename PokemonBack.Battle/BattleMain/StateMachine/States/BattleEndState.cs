using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattleEndState : BattleStateBase
	{
		protected BattleSession _battle;

		public BattleEndState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{
		}

		public override void OnBattleMemberAction()
		{
			
		}

		public override void OnStart()
		{
			StateLog = new BattleEndLog(_battle.Id);
			_battle.OnStateChange(StateLog);
			_battle.OnBattleEnd();
		}

		public override void OnStop()
		{
			
		}
       
    }
}

using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattlePokemonChooseState : BattleStateBase
	{
		public BattlePokemonChooseState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{

		}

		public override void OnBattleMemberAction()
		{
			PokemonReadyCheck();
		}

		public override void OnStart()
		{
			BattleMemberActionSubscribe();
		}

		public override void OnStop()
		{
			StateLog = new ChoosePokemonLog(_battle.FirstBattleMember.GetId(), _battle.FirstBattleMember.ActivePokemon.Id, _battle.SecondBattleMember.GetId(), _battle.SecondBattleMember.ActivePokemon.Id);
			_battle.OnStateChange(StateLog);
			BattleMemberActionUnSubscribe();
		}
		private void PokemonReadyCheck()
		{
			if(_battle.FirstBattleMember.IsReady() & _battle.SecondBattleMember.IsReady())
			{
				_battle.FirstBattleMember.MakeMove();
				_battle.SecondBattleMember.MakeMove();
				
				_battleStateMachine.SwitchState<BattleTurnStartState>();
			}
		}
	}
}

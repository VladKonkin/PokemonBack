using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
	public class BattleTurnSwitchWaitState : BattleStateBase
	{
		private BattleMember _switcher;
		private TurnAction _switcherData;
		public BattleTurnSwitchWaitState(BattleStateMachine battleStateMachine, BattleSession battle) : base(battleStateMachine, battle)
		{
		}
		public override void OnBattleMemberAction()
		{
			CheckPokemonSwitchReady();
		}

		public override void OnStart()
		{
			CheckSwitcher();
			BattleMemberActionSubscribe();
		}

		public override void OnStop()
		{
			_battle.OnStateChange(StateLog);

			BattleMemberActionUnSubscribe();
			ClearSwitchData();
		}

		private void ClearSwitchData()
		{
			_switcher = null;
			_switcherData = null;
		}

		private void CheckPokemonSwitchReady()
		{
			if(_switcher.ActiveTurnAction != _switcherData)
			{
				var prevPokemon = _switcher.ActivePokemon;

				_switcher.MakeMove();
				StateLog = new SwitchPokemonLog(_switcher.GetId(), prevPokemon.Id, _switcher.ActivePokemon.Id);

				_battleStateMachine.SwitchState<BattleTurnEndState>();
			}
		}
		private void CheckSwitcher()
		{
			_switcher = _battle.FirstBattleMember.ActivePokemon.IsAlive ? _battle.SecondBattleMember : _battle.FirstBattleMember;
			_switcherData = _switcher.ActiveTurnAction;

		}
	}
}

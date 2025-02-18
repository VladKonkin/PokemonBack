using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.BattleMain.StateMachine.States
{
    public abstract class BattleStateBase
    {
        protected readonly BattleStateMachine _battleStateMachine;
        protected readonly BattleSession _battle;
        public StateLogBase StateLog { get; protected set; }
        protected BattleStateBase(BattleStateMachine battleStateMachine,BattleSession battle)
        {
            _battleStateMachine = battleStateMachine;
            _battle = battle;
        }
        public abstract void OnStart();
        public abstract void OnStop();
        public abstract void OnBattleMemberAction();
		protected void BattleMemberActionSubscribe()
		{
			_battle.FirstBattleMember.BattleTurnSetAction += OnBattleMemberAction;
			_battle.SecondBattleMember.BattleTurnSetAction += OnBattleMemberAction;
		}
		protected void BattleMemberActionUnSubscribe()
		{
			_battle.FirstBattleMember.BattleTurnSetAction -= OnBattleMemberAction;
			_battle.SecondBattleMember.BattleTurnSetAction -= OnBattleMemberAction;
		}
        
	}
}

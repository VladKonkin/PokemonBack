using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.BattleMain.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;

namespace PokemonBack.Battle.BattleMain
{
	public class BattleSession
	{
		public Guid Id { get; }

        public BattleMember FirstBattleMember { get; private set; }
		public BattleMember SecondBattleMember { get; private set; }
        public BattleLoger BattleLoger {get;}

		private BattleStateMachine _stateMachine;

        public Action<StateLogBase> OnStateChangeAction;
        
        public int TurnNumber { get; private set; }
        public BattleSession(Guid id, BattleMember firstBattleMember,BattleMember secondBattleMember)
        {
            Id = id;
            TurnNumber = 0;

            FirstBattleMember = firstBattleMember;
            SecondBattleMember = secondBattleMember;

            _stateMachine = new BattleStateMachine(this);

            BattleLoger = new BattleLoger(this);
		}
       
        public void OnTurnEnd()
        {
            TurnNumber++;
        }
        public void OnStateChange(StateLogBase stateLog)
        {
            OnStateChangeAction?.Invoke(stateLog);
		}
        public void OnBattleEnd()
        {

		}
    }
}

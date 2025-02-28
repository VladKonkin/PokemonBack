using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.Battle.BattleMain.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBack.Battle.Models.TurnDataCore.StatesLog;
using Newtonsoft.Json;

namespace PokemonBack.Battle.BattleMain
{
	public class BattleSession
	{
		public Guid Id { get; }

        public BattleMember FirstBattleMember { get; private set; }
		public BattleMember SecondBattleMember { get; private set; }
		[JsonIgnore] public BattleLoger BattleLoger {get;}

		[JsonIgnore] private BattleStateMachine _stateMachine;

		[JsonIgnore] public Action<Guid, StateLogBase> OnStateChangeAction;
		[JsonIgnore] public Func<BattleSession,Task> OnBattleEndAction;
        [JsonIgnore] public Action OnTurnEndAction;
        
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
            OnTurnEndAction?.Invoke();

		}
        public void OnStateChange(StateLogBase stateLog)
        {
            OnStateChangeAction?.Invoke(Id,stateLog);
		}
        public void OnBattleEnd()
        {
            OnBattleEndAction?.Invoke(this);
		}
        
    }
}

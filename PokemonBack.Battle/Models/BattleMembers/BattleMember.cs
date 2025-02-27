using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonBack.Battle.BattleMain;
using PokemonBack.ServiceDefaults.Data.DTO;
using PokemonBack.Battle.Models.TurnDataCore;


namespace PokemonBack.Battle.Models.BattleMembers
{
    public abstract class BattleMember
    {
        protected BattleSession _battleSession;
		
		protected TurnAction _activeTurnAction;
        protected List<PokemonModel> _pokemonList;

        protected PokemonModel _activePokemon;

        public TurnAction ActiveTurnAction => _activeTurnAction;
        public PokemonModel ActivePokemon => _activePokemon;
        public Action BattleTurnSetAction { get; set; }
        
        public bool CantСontinueBattle()
        {
            PokemonModel pokemon = _pokemonList.FirstOrDefault(p => p.IsAlive);
            return pokemon == null;
        }
        public PokemonModel GetPokemonById(string id)
        {
            return _pokemonList.FirstOrDefault(p => p.Id == id);
        }
        public virtual void SetBattle(BattleSession battleSession) => _battleSession = battleSession;
        public bool IsReady() => _activeTurnAction != null;
        public virtual void ClearTurnAction() => _activeTurnAction = null;
        public abstract void SetTurnData(TurnAction turnData);
        public abstract void SetMoveId(string? id);
        public abstract void OnTurnEnd();
        public abstract void ChoosePokemon(PokemonModel pokemonDTO);
        public virtual void MakeMove(BattleMember defender)
        {
            _activeTurnAction.Execute(defender);
        }
        public virtual void MakeMove()
        {
            _activeTurnAction.Execute();
        }
        public virtual string GetId()
        {
            return "0";
        }
    }
}

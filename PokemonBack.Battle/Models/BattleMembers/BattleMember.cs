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
		protected TurnData _activeTurnData;
        protected List<PokemonDTO> _pokemonList;

        protected PokemonDTO _activePokemon;

        public TurnData ActiveTurnData => _activeTurnData;
        public PokemonDTO ActivePokemon => _activePokemon;
        public Action BattleTurnSetAction { get; set; }
        
        public bool CantСontinueBattle()
        {
            PokemonDTO pokemon = _pokemonList.First(p => p.IsAlive);
            return pokemon == null;
        }
        public PokemonDTO GetPokemonById(Guid id)
        {
            return _pokemonList.FirstOrDefault(p => p.Id == id);
        }
        public virtual void SetBattle(BattleSession battleSession) => _battleSession = battleSession;
        public bool IsReady() => _activeTurnData != null;
        public virtual void NextTurnStart() => _activeTurnData = null;
        public abstract void SetTurnData(TurnData turnData);
        public abstract void SetMoveId(Guid? id);
        public abstract void OnTurnEnd();
        public abstract void ChoosePokemon(PokemonDTO pokemonDTO);
        public virtual void MakeMove(BattleMember defender)
        {
            _activeTurnData.Action.Execute(defender);
        }
        public virtual void MakeMove()
        {
            _activeTurnData.Action.Execute();
        }
        public virtual Guid GetId()
        {
            return Guid.Empty;
        }
    }
}

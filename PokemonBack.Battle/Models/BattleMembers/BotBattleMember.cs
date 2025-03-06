using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.ServiceDefaults.Data.DTO;
using PokemonBack.ServiceDefaults.Data.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.BattleMembers
{
	public class BotBattleMember : BattleMember
	{
		Random _rnd;
        public BotBattleMember()
        {
			_rnd = new Random();
			_pokemonList = new List<PokemonModel>();
			InitPokemon();
		}
		private void InitPokemon()
		{
			var testData = new TestDataUserModel();
			var pokemon = testData.GenerateTestPokemon(GetId(), "0");
			_pokemonList.Add(pokemon);
			_activeTurnAction = new SwitchAction(pokemon.Id, this);
		}
		public override void OnNextTurnStart()
		{
            Console.WriteLine("Next Turn Start");
			base.OnNextTurnStart();
			SetMoveId(_activePokemon.Moves[_rnd.Next(4)].Id);
		}

		public override void OnTurnEnd()
		{
			
		}
		public override void SetMoveId(string? id)
		{
			var move = ActivePokemon.Moves.FirstOrDefault(x => x.Id == id);
			var turn = new MoveAction(ActivePokemon, move);
			SetTurnData(turn);
		}

		public override void SetTurnData(TurnAction turnData)
		{
			_activeTurnAction = turnData;
			BattleTurnSetAction?.Invoke();
		}
	}
}

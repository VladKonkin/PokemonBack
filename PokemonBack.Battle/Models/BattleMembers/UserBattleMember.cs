using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.BattleMembers
{
    public class UserBattleMember : BattleMember
	{
		[JsonProperty] private UserModel _user;
        public UserBattleMember(UserModel user)
        {
			_user = user;
            _pokemonList = user.Pokemons;
        }

        public override void SetTurnData(TurnAction turnData)
		{
			_activeTurnAction = turnData;
			BattleTurnSetAction?.Invoke();
		}
		public override void ClearTurnAction()
		{
            Console.WriteLine($"Next Turn user id {_user.Id}");
			base.ClearTurnAction();
		}
		public string GetTestUserJson()
		{
			return JsonConvert.SerializeObject(_user);
		}
		public override void OnTurnEnd()
		{
			
		}

		public override void ChoosePokemon(PokemonModel pokemonDTO)
		{
			_activePokemon = pokemonDTO;
		}
		public override string GetId()
		{
			return _user.Id;
		}

		public override void SetMoveId(string? id)
		{
            Console.WriteLine("ActivePokId " + ActivePokemon.Id);
            Console.WriteLine("ActivePokMoveList " + ActivePokemon.Moves.Count);
			var move = ActivePokemon.Moves.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Move " + move);
			var turn = new MoveAction(ActivePokemon,move);
            Console.WriteLine("Turn " + turn);
			SetTurnData(turn);
		}

	}
}

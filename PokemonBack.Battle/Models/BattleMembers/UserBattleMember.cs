﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using PokemonBack.Battle.Models.TurnDataCore;
using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PokemonBack.Battle.Models.BattleMembers
{
	public class UserBattleMember : BattleMember
	{
		[JsonProperty] private UserModel _user;
		[JsonIgnore] private ActionValidator _validator;
        public UserBattleMember(UserModel user)
        {
			_user = user;
            _pokemonList = user.Pokemons;
			_validator = new ActionValidator();

		}

        public override void SetTurnData(TurnAction turnData, Action<string> callBack)
		{
			var validation = _validator.Validate(turnData, callBack);
			if (validation != null) 
			{
				callBack?.Invoke(validation);
				return;
			}
			//TODO
			_activeTurnAction = turnData;
			BattleTurnSetAction?.Invoke();
		}
		public string GetTestUserJson()
		{
			return JsonConvert.SerializeObject(_user);
		}
		public override void OnTurnEnd()
		{
			
		}

		public override string GetId()
		{
			return _user.Id;
		}

		public override void SetMoveId(string? id, Action<string> callBack)
		{


			var move = ActivePokemon.Moves.FirstOrDefault(x => x.Id == id);
			var turn = new MoveAction(ActivePokemon,move);
			SetTurnData(turn, callBack);
		}

		public override void OnNextTurnStart()
		{
			Console.WriteLine($"Next Turn user id {_user.Id}");
			base.OnNextTurnStart();
		}
	}
}

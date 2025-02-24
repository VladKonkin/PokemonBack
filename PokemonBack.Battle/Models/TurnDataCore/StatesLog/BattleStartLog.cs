﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class BattleStartLog : StateLogBase
	{
		[JsonProperty] public Guid BattleId { get; set; }
		[JsonProperty] public string FirstPlayerId { get; set; }
		[JsonProperty] public string SecondPlayerId { get; set; }
		public BattleStartLog(string playerId, string secondPlayerId, Guid battleId) : base("BattleStart")
		{
			FirstPlayerId = playerId;
			SecondPlayerId = secondPlayerId;
			BattleId = battleId;
		}
	}
}

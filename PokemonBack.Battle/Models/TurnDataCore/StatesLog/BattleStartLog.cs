﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore.StatesLog
{
	public class BattleStartLog : StateLogBase
	{
		public Guid BattleId { get; set; }
		public Guid FirstPlayerId { get; set; }
		public Guid SecondPlayerId { get; set; }
		public BattleStartLog(Guid playerId,Guid secondPlayerId, Guid battleId) : base("BattleStart")
		{
			FirstPlayerId = playerId;
			SecondPlayerId = secondPlayerId;
			BattleId = battleId;
		}
	}
}

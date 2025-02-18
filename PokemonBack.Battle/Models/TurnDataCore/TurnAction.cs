using PokemonBack.Battle.Models.BattleMembers;
using PokemonBack.ServiceDefaults.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.Battle.Models.TurnDataCore
{
	public abstract class TurnAction
	{
		public abstract string Description { get; }

		public int Priority { get; protected set; }
		public abstract void Execute(BattleMember target);
		public abstract void Execute();
		public virtual PokemonDTO? Pokemon => null;
		public virtual MoveDTO? Move => null;
		public virtual BattleMember? BattleMember => null;
	}
}

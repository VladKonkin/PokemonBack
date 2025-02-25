using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class BattleLogEntity
	{
		public Guid Id { get; set; }
		public string FirstBattleMemberId { get; set; }
		public string SecondBattleMemberId { get; set; }
		public string BattleLogJson { get; set; }
	}
}

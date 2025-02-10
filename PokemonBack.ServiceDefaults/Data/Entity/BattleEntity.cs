using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class BattleEntity
	{
		public Guid Id { get; set; }
		public UserEntity FirstUser { get; set; }
		public UserEntity SecondUser { get; set; }
		public TimeSpan StartTime { get; set; }
		
	}
}

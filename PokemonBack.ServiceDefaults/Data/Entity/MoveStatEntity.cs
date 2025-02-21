using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class MoveStatEntity
	{
		public Guid Id {  get; set; }
		public PokemonType Element { get; set; }
		public int Power { get; set; }
		public int Accuracy { get; set; }
		public int MaxPP { get; set; }
		public int CurrentPP { get; set; }
		public MoveEntity MoveEntity { get; set; }
		public Guid MoveId { get; set; }
	}
}

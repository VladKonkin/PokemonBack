using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class PokemonStatEntity
	{
		public Guid Id { get; set; }
		public int Level { get; set; }
		public int MaxHp { get; set; }
		public int CurrentHp { get; set; }
		public int Attack { get; set; }
		public int SpAttack { get; set; }
		public int Defence { get; set; }
		public int SpDefence { get; set; }
		public int Speed { get; set; }
		public Element Element { get; set; }

		public PokemonEntity PokemonEntity { get; set; }
		public Guid PokemonId { get; set; }
	}
	public enum Element
	{
		Fire,
		Water,
		Grass,
		Electric,
		Normal
	}
}


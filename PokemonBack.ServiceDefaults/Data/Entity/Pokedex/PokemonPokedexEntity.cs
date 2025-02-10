using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity.Pokedex
{
	public class PokemonPokedexEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Level { get; set; }
		public int MaxHp { get; set; }
		public int Attack { get; set; }
		public int SpAttack { get; set; }
		public int Defence { get; set; }
		public int SpDefence { get; set; }
		public int Speed { get; set; }
		public Element Element { get; set; }
		//public List<PokemonEntity> Pokemons { get; set; }
	}
}

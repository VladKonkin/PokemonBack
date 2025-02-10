using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class MoveEntity
	{
		public Guid Id { get; set; }

		public PokemonEntity PokemonEntity { get; set; }
		public Guid PokemonId { get; set; }

		public Element Element { get; set; }
		public int Power { get; set; }
		public int Accuracy { get; set; }
		public int MaxPP { get; set; }
		public int CurrentPP { get; set; }

		//public MovePokedexEntity MovePokedexEntity { get; set; }
		public Guid MovePokedexId { get; set; }
	}
}

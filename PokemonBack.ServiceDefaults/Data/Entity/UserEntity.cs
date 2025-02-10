using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.Entity
{
	public class UserEntity
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public List<PokemonEntity> Pokemons { get; set; }
	}
}

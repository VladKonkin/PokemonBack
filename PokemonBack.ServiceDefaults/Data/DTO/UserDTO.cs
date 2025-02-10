using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class UserDTO
	{
		public Guid Id { get;  set; }
		public string UserName { get;  set; }
		public List<PokemonDTO> Pokemons { get; set; }
        public UserDTO()
        {
            
        }
        public UserDTO(UserEntity userEntity)
        {
            Id = userEntity.UserId;
            UserName = userEntity.UserName;
            Pokemons = userEntity.Pokemons
                .Select(p => new PokemonDTO(p))
                .ToList();
            Pokemons.ForEach(p => p.Moves
            .Select(m => m.PokemonDTO = p));
        }

    }
}

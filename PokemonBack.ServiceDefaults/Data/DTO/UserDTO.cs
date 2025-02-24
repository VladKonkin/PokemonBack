using Newtonsoft.Json;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class UserDTO
	{
		//public Guid Id { get;  set; }
		[JsonProperty] public string Id { get;  set; }
		[JsonProperty] public string UserName { get;  set; }
		[JsonProperty] public List<PokemonDTO> Pokemons { get; set; }
        public UserDTO()
        {
            
        }
        //public UserDTO(UserEntity userEntity)
        //{
        //    Id = userEntity.UserId;
        //    UserName = userEntity.UserName;
        //    Pokemons = userEntity.Pokemons
        //        .Select(p => new PokemonDTO(p))
        //        .ToList();
        //    Pokemons.ForEach(p => p.Moves
        //    .Select(m => m.PokemonDTO = p));
        //}

    }
}

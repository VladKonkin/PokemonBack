using PokemonBack.ServiceDefaults.Data.DTO;

namespace PokemonBack.BotBattleAPI.DTO
{
	public class UserInfoDTO
	{
		public string UserId {  get; set; }
		public List<PokemonModel> Pokemons { get; set; }
	}
}

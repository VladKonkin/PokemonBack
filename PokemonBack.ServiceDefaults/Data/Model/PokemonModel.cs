using Newtonsoft.Json;
using PokemonBack.ServiceDefaults.Data.Model;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class PokemonModel
	{
		//public Guid Id { get;  set; }
		[JsonProperty] public string Id { get;  set; }
		[JsonProperty] public string Name { get;  set; }
		[JsonProperty] public PokemonAbillityModel Ability { get;  set; }
		[JsonProperty] public int Level { get; set; }
		[JsonProperty] public int MaxHp { get; set; }
		[JsonProperty] public int CurrentHp { get; set; }
		[JsonProperty] public int Attack { get; set; }
		[JsonProperty] public int SpAttack { get; set; }
		[JsonProperty] public int Defence { get; set; }
		[JsonProperty] public int SpDefence { get; set; }
		[JsonProperty] public int Speed { get; set; }
		[JsonProperty] public bool IsAlive => CurrentHp > 0;
		[JsonProperty] public PokemonType PokemonType { get; set; }
		[JsonProperty] public PokemonType SecondPokemonType { get; set; }
		[JsonProperty] public MoveCategory MoveCategory { get;  set; }
		[JsonProperty] public List<MoveModel> Moves { get; set; }

        public PokemonModel()
        {
            
        }
   //     public PokemonDTO()
   //     {
   //         Id = pokemonEntity.Id;
			//Level = pokemonEntity.Level;
			//MaxHp = pokemonEntity.MaxHp;
			//CurrentHp = pokemonEntity.CurrentHp;
			//Attack = pokemonEntity.Attack;
			//SpAttack = pokemonEntity.SpAttack;
			//Defence = pokemonEntity.Defence;
			//SpDefence = pokemonEntity.SpDefence;
			//Speed = pokemonEntity.Speed;
			//Element = pokemonEntity.Element;
			//Moves = pokemonEntity.Moves
			//	.Select(m => new MoveDTO(m))
			//	.ToList();
   //     }
    }
}
public enum MoveCategory
{
	Physical,
	Special,
	Status
}

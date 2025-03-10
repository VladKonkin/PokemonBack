﻿using Newtonsoft.Json;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class PokemonModel
	{
		//public Guid Id { get;  set; }
		[JsonProperty] public string Id { get;  set; }
		[JsonProperty] public int Level { get; set; }
		[JsonProperty] public int MaxHp { get; set; }
		[JsonProperty] public int CurrentHp { get; set; }
		[JsonProperty] public int Attack { get; set; }
		[JsonProperty] public int SpAttack { get; set; }
		[JsonProperty] public int Defence { get; set; }
		[JsonProperty] public int SpDefence { get; set; }
		[JsonProperty] public int Speed { get; set; }
		[JsonProperty] public bool IsAlive => CurrentHp > 0;
		[JsonProperty] public PokemonType Element { get; set; }
		[JsonProperty] public List<MoveModel> Moves { get; set; }
		[JsonIgnore] public UserModel User { get; set; }

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
		public void SetUser(UserModel user)
		{
			User = user;
		}
    }
}

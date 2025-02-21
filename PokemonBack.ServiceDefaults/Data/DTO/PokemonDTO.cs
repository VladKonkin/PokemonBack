using PokemonBack.ServiceDefaults.Data.Entity.Pokedex;
using PokemonBack.ServiceDefaults.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Data.DTO
{
	public class PokemonDTO
	{
		public Guid Id { get;  set; }
		public int Level { get; set; }
		public int MaxHp { get; set; }
		public int CurrentHp { get; set; }
		public int Attack { get; set; }
		public int SpAttack { get; set; }
		public int Defence { get; set; }
		public int SpDefence { get; set; }
		public int Speed { get; set; }
		public bool IsAlive => CurrentHp > 0;
		public PokemonType Element { get; set; }
		public List<MoveDTO> Moves { get; set; }
		public UserDTO User { get; set; }

        public PokemonDTO()
        {
            
        }
        public PokemonDTO(PokemonEntity pokemonEntity)
        {
            Id = pokemonEntity.Id;
			Level = pokemonEntity.Level;
			MaxHp = pokemonEntity.MaxHp;
			CurrentHp = pokemonEntity.CurrentHp;
			Attack = pokemonEntity.Attack;
			SpAttack = pokemonEntity.SpAttack;
			Defence = pokemonEntity.Defence;
			SpDefence = pokemonEntity.SpDefence;
			Speed = pokemonEntity.Speed;
			Element = pokemonEntity.Element;
			Moves = pokemonEntity.Moves
				.Select(m => new MoveDTO(m))
				.ToList();
        }
		public void SetUser(UserDTO user)
		{
			User = user;
		}
    }
}
